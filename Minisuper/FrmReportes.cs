using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Minisuper.Datos;

namespace Minisuper
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteDAO _reporteDAO = new ReporteDAO();
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private ComboBox cmbGranularidad;
        private Button btnGenerar;
        private Button btnExportarPdf;
        private WebBrowser webVistaPrevia;

        public FrmReportes()
        {
            InitializeComponent();
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            this.Text = "Reporte de Ventas y Cobranzas - Minisúper El Ahorro";
            this.Size = new System.Drawing.Size(960, 680);
            this.StartPosition = FormStartPosition.CenterScreen;

            Panel panelTop = new Panel { Dock = DockStyle.Top, Height = 65, BackColor = System.Drawing.Color.FromArgb(30, 41, 59) };

            Label lblDesde = new Label { Text = "Desde:", ForeColor = System.Drawing.Color.White, Left = 15, Top = 22, AutoSize = true };
            dtpInicio = new DateTimePicker { Left = 65, Top = 18, Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddMonths(-1) };

            Label lblHasta = new Label { Text = "Hasta:", ForeColor = System.Drawing.Color.White, Left = 200, Top = 22, AutoSize = true };
            dtpFin = new DateTimePicker { Left = 248, Top = 18, Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            Label lblTipo = new Label { Text = "Vista:", ForeColor = System.Drawing.Color.White, Left = 385, Top = 22, AutoSize = true };
            cmbGranularidad = new ComboBox { Left = 428, Top = 18, Width = 115, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbGranularidad.Items.AddRange(new object[] { "Diario", "Mensual" });
            cmbGranularidad.SelectedIndex = 0;

            btnGenerar = new Button { Text = "Generar Reporte", Left = 560, Top = 16, Width = 140, Height = 30, BackColor = System.Drawing.Color.FromArgb(37, 99, 235), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnGenerar.Click += BtnGenerar_Click;

            btnExportarPdf = new Button { Text = "Imprimir / PDF", Left = 715, Top = 16, Width = 135, Height = 30, BackColor = System.Drawing.Color.FromArgb(22, 163, 74), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnExportarPdf.Click += (s, e) => webVistaPrevia.ShowPrintDialog();

            panelTop.Controls.AddRange(new Control[] { lblDesde, dtpInicio, lblHasta, dtpFin, lblTipo, cmbGranularidad, btnGenerar, btnExportarPdf });

            webVistaPrevia = new WebBrowser { Dock = DockStyle.Fill };

            this.Controls.Add(webVistaPrevia);
            this.Controls.Add(panelTop);
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cmbGranularidad.SelectedItem.ToString();
                DataTable dt = _reporteDAO.ObtenerReporteVentas(dtpInicio.Value, dtpFin.Value, tipo);

                // Prueba 3: Escenario sin datos (UX amigable)
                if (dt.Rows.Count == 0)
                {
                    btnExportarPdf.Enabled = false;
                    webVistaPrevia.DocumentText = "";
                    MessageBox.Show(
                        "No existen ventas registradas en el rango de fechas seleccionado. Intente ampliar el periodo de búsqueda.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                string html = ConstruirHtmlReporte(dt, tipo, dtpInicio.Value, dtpFin.Value);
                webVistaPrevia.DocumentText = html;
                btnExportarPdf.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un inconveniente inesperado al generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConstruirHtmlReporte(DataTable dt, string tipo, DateTime inicio, DateTime fin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><style>");
            sb.Append("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 25px; color: #1e293b; }");
            sb.Append(".header { border-bottom: 2px solid #0f172a; padding-bottom: 10px; margin-bottom: 18px; }");
            sb.Append(".header h1 { margin: 0; font-size: 20px; color: #0f172a; }");
            sb.Append(".meta { font-size: 12px; color: #475569; margin-top: 5px; }");
            sb.Append(".group-header { background: #e2e8f0; padding: 7px 10px; font-weight: bold; margin-top: 15px; border-left: 4px solid #2563eb; }");
            sb.Append("table { width: 100%; border-collapse: collapse; font-size: 13px; margin-top: 5px; }");
            sb.Append("th { background: #1e293b; color: white; padding: 6px; text-align: left; }");
            sb.Append("td { border-bottom: 1px solid #cbd5e1; padding: 6px; }");
            sb.Append(".num { text-align: right; }");
            sb.Append(".group-footer { background: #f8fafc; font-weight: bold; }");
            sb.Append(".report-footer { margin-top: 25px; padding: 12px; background: #0f172a; color: white; font-size: 15px; font-weight: bold; text-align: right; }");
            sb.Append("</style></head><body>");

            sb.Append("<div class='header'>");
            sb.Append($"<h1>MINISÚPER EL AHORRO — REPORTE DE VENTAS ({tipo.ToUpper()})</h1>");
            sb.Append($"<div class='meta'><b>Periodo filtrado:</b> {inicio:dd/MM/yyyy} al {fin:dd/MM/yyyy} &nbsp;|&nbsp; <b>Fecha emisión:</b> {DateTime.Now:dd/MM/yyyy HH:mm} &nbsp;|&nbsp; <b>Generado por:</b> Administrador</div>");
            sb.Append("</div>");

            var grupos = dt.AsEnumerable().GroupBy(r => r["periodo_grupo"].ToString());
            decimal granTotalCobrado = 0;
            decimal granTotalDescuento = 0;

            foreach (var grupo in grupos)
            {
                string etiquetaGrupo = tipo == "Mensual" ? $"Periodo Mensual: {grupo.Key}" : $"Fecha Operativa: {grupo.Key}";
                sb.Append($"<div class='group-header'>{etiquetaGrupo}</div>");
                sb.Append("<table><thead><tr>");

                if (tipo == "Mensual")
                    sb.Append("<th>Fecha Día</th><th class='num'>Cant. Ventas</th><th class='num'>Subtotal Bruto (Bs.)</th><th class='num'>Descuentos (Bs.)</th><th class='num'>Total Cobrado (Bs.)</th>");
                else
                    sb.Append("<th>Nro. Venta</th><th>Hora</th><th>Vendedor</th><th class='num'>Subtotal (Bs.)</th><th class='num'>Descuento (Bs.)</th><th class='num'>Total Cobrado (Bs.)</th>");

                sb.Append("</tr></thead><tbody>");

                decimal subDescuento = 0;
                decimal subCobrado = 0;
                int totalOperaciones = 0;

                foreach (DataRow row in grupo)
                {
                    decimal desc = Convert.ToDecimal(row["monto_descuento"]);
                    decimal cobrado = Convert.ToDecimal(row["total_cobrado"]);
                    decimal bruto = Convert.ToDecimal(row["subtotal_bruto"]);
                    subDescuento += desc;
                    subCobrado += cobrado;

                    if (tipo == "Mensual")
                    {
                        int cant = Convert.ToInt32(row["cantidad_ventas"]);
                        totalOperaciones += cant;
                        sb.Append($"<tr><td>{row["detalle_fecha"]}</td><td class='num'>{cant}</td><td class='num'>{bruto:N2}</td><td class='num'>{desc:N2}</td><td class='num'>{cobrado:N2}</td></tr>");
                    }
                    else
                    {
                        totalOperaciones++;
                        sb.Append($"<tr><td>#{row["nro_venta"]}</td><td>{row["hora"]}</td><td>{row["vendedor"]}</td><td class='num'>{bruto:N2}</td><td class='num'>{desc:N2}</td><td class='num'>{cobrado:N2}</td></tr>");
                    }
                }

                int colspan = tipo == "Mensual" ? 3 : 4;
                sb.Append($"<tr class='group-footer'><td colspan='{colspan}'>Subtotal Grupo ({totalOperaciones} operaciones)</td><td class='num'>Bs. {subDescuento:N2}</td><td class='num'>Bs. {subCobrado:N2}</td></tr>");
                sb.Append("</tbody></table>");

                granTotalDescuento += subDescuento;
                granTotalCobrado += subCobrado;
            }

            sb.Append($"<div class='report-footer'>Total Descuentos: Bs. {granTotalDescuento:N2} &nbsp;&nbsp;|&nbsp;&nbsp; GRAN TOTAL COBRADO: Bs. {granTotalCobrado:N2} &nbsp;&nbsp;|&nbsp;&nbsp; Página 1 de 1</div>");
            sb.Append("</body></html>");

            return sb.ToString();
        }
    }
}
