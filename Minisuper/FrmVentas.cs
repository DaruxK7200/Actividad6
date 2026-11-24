using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minisuper.Datos;
using Minisuper.Modelos;

namespace Minisuper
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();

        }
        private void CargarProductos()
        {
            ProductoDAO dao = new ProductoDAO();

            cmbProductos.DataSource = dao.ObtenerProductos();

            cmbProductos.DisplayMember = "Nombre";

            cmbProductos.ValueMember = "Id";
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            dgvDetalleVenta.EnableHeadersVisualStyles = false;

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 41, 59);

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDetalleVenta.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            CargarProductos();
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(30, 41, 59);

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;

            dgvDetalleVenta.EnableHeadersVisualStyles = false;
        }

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.FromArgb(59, 130, 246);
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void btnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btnConfirmar.BackColor = Color.LightGreen;
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btnConfirmar.BackColor = Color.ForestGreen;
        }

        private void btnQuitar_MouseEnter(object sender, EventArgs e)
        {
            btnQuitar.BackColor = Color.IndianRed;
        }

        private void btnQuitar_MouseLeave(object sender, EventArgs e)
        {
            btnQuitar.BackColor = Color.Firebrick;
        }

        private decimal totalFinal = 0;
        private decimal subtotal = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto =
                (Producto)cmbProductos.SelectedItem;

            int cantidad = (int)numericUpDown1.Value;

            decimal subtotalProducto =
            producto.Precio * cantidad;

            dgvDetalleVenta.Rows.Add(
            producto.Id,
            producto.Nombre,
            cantidad,
            producto.Precio,
            subtotalProducto);

            subtotal += subtotalProducto;

            CalcularTotales();

            lblTotalFinal.Text = $"Bs. {totalFinal:F2}";
        }

        private void btnQuitar_Click(object sender, EventArgs e)        
        {
            if (dgvDetalleVenta.SelectedRows.Count > 0)
            {
                decimal subtotalProducto =
                    Convert.ToDecimal(
                        dgvDetalleVenta.SelectedRows[0]
                        .Cells["CSubtotal"].Value);

                subtotal -= subtotalProducto;

                CalcularTotales();

                lblTotalFinal.Text = $"Bs. {totalFinal:F2}";

                dgvDetalleVenta.Rows.RemoveAt(
                    dgvDetalleVenta.SelectedRows[0].Index);
            }
        
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un producto.",
                    "Advertencia");

                return;
            }
            if (numDescuento.Value > 20)
            {
                MessageBox.Show(
                    "El descuento no puede superar el 20%.",
                    "Validación");

                return;
            }
            if (string.IsNullOrWhiteSpace(
    txtVendedor.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del vendedor.",
                    "Validación");

                txtVendedor.Focus();

                return;
            }

            VentaDAO ventaDAO = new VentaDAO();

            decimal porcentaje =
    numDescuento.Value;

            decimal montoDescuento =
                subtotal * porcentaje / 100;

            int ventaId =
                ventaDAO.RegistrarVenta(
                    dtpFecha.Value,
                    totalFinal,
                    txtVendedor.Text,
                    subtotal,
                    porcentaje,
                    montoDescuento,
                    totalFinal);

            DetalleVentaDAO detalleDAO =
                new DetalleVentaDAO();

            foreach (DataGridViewRow fila
                     in dgvDetalleVenta.Rows)
            {
                int productoId =
                    Convert.ToInt32(
                        fila.Cells["CID"].Value);

                int cantidad =
                    Convert.ToInt32(
                        fila.Cells["CCantidad"].Value);

                decimal precio =
                    Convert.ToDecimal(
                        fila.Cells["CPrecio"].Value);

                detalleDAO.RegistrarDetalle(
                    ventaId,
                    productoId,
                    cantidad,
                    precio);
            }

            MessageBox.Show(
                "Venta registrada correctamente.");

            dgvDetalleVenta.Rows.Clear();

            subtotal = 0;

            txtVendedor.Clear();

            numDescuento.Value = 0;

            lblSubtotal.Text = "Bs. 0.00";

            lblMontoDescuento.Text = "Bs. 0.00";

            lblTotalFinal.Text = "Bs. 0.00";
        }
        private void CalcularTotales()
        {
            decimal porcentaje =
                numDescuento.Value;

            decimal montoDescuento =
                subtotal * porcentaje / 100;

            totalFinal =
                subtotal - montoDescuento;

            lblSubtotal.Text =
                $"Bs. {subtotal:F2}";

            lblMontoDescuento.Text =
                $"Bs. {montoDescuento:F2}";

            lblTotalFinal.Text =
                $"Bs. {totalFinal:F2}";
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }
    }
}
