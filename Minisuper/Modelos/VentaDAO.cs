using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Minisuper.Datos
{
    public class VentaDAO
    {
        Conexion conexion = new Conexion();

        public int RegistrarVenta(
        DateTime fecha,
        decimal total,
        string vendedor,
        decimal subtotalBruto,
        decimal porcentajeDescuento,
        decimal montoDescuento,
        decimal totalFinal)
        {
                int ventaId = 0;

                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                string sql = @"
                INSERT INTO ventas
                (
                    fecha,
                    total,
                    vendedor,
                    subtotal_bruto,
                    porcentaje_descuento,
                    monto_descuento,
                    total_final
                )
                VALUES
                (
                    @fecha,
                    @total,
                    @vendedor,
                    @subtotal,
                    @porcentaje,
                    @descuento,
                    @totalfinal
                )
                RETURNING id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    cmd.Parameters.AddWithValue("@total", total);

                    cmd.Parameters.AddWithValue("@vendedor", vendedor);

                    cmd.Parameters.AddWithValue("@subtotal", subtotalBruto);

                    cmd.Parameters.AddWithValue("@porcentaje", porcentajeDescuento);

                    cmd.Parameters.AddWithValue("@descuento", montoDescuento);

                    cmd.Parameters.AddWithValue("@totalfinal", totalFinal);

                    ventaId = Convert.ToInt32(
                            cmd.ExecuteScalar());
                    }
                }

                return ventaId;
        }
    }
}
