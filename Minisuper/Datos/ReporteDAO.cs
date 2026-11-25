using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Minisuper.Datos
{
    public class ReporteDAO
    {
        private readonly Conexion _conexion = new Conexion();

        public DataTable ObtenerReporteVentas(DateTime inicio, DateTime fin, string tipoGranularidad)
        {
            if (inicio.Date > fin.Date)
                throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha final.");

            DataTable dt = new DataTable("ReporteVentas");
            NpgsqlConnection conn = null;

            try
            {
                conn = _conexion.ObtenerConexion();
                conn.Open();

                string sql = tipoGranularidad == "Mensual"
                    ? @"SELECT 
                            TO_CHAR(fecha, 'YYYY-MM') AS periodo_grupo,
                            TO_CHAR(fecha, 'YYYY-MM-DD') AS detalle_fecha,
                            COUNT(id) AS cantidad_ventas,
                            COALESCE(SUM(subtotal_bruto), 0) AS subtotal_bruto,
                            COALESCE(SUM(monto_descuento), 0) AS monto_descuento,
                            COALESCE(SUM(COALESCE(total_final, total)), 0) AS total_cobrado
                        FROM ventas
                        WHERE fecha::date BETWEEN @inicio AND @fin
                        GROUP BY TO_CHAR(fecha, 'YYYY-MM'), TO_CHAR(fecha, 'YYYY-MM-DD')
                        ORDER BY periodo_grupo ASC, detalle_fecha ASC;"
                    : @"SELECT 
                            TO_CHAR(fecha, 'YYYY-MM-DD') AS periodo_grupo,
                            id AS nro_venta,
                            TO_CHAR(fecha, 'HH24:MI') AS hora,
                            COALESCE(vendedor, 'Sin registrar') AS vendedor,
                            COALESCE(subtotal_bruto, total) AS subtotal_bruto,
                            COALESCE(monto_descuento, 0) AS monto_descuento,
                            COALESCE(total_final, total) AS total_cobrado
                        FROM ventas
                        WHERE fecha::date BETWEEN @inicio AND @fin
                        ORDER BY fecha ASC;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("inicio", inicio.Date);
                    cmd.Parameters.AddWithValue("fin", fin.Date);

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                return dt;
            }
            catch (NpgsqlException ex)
            {
                Logger.Registrar(ex);
                throw new InvalidOperationException("No pudimos consultar los datos para generar el reporte. Verifique la conexión con PostgreSQL.");
            }
            catch (Exception ex)
            {
                Logger.Registrar(ex);
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
