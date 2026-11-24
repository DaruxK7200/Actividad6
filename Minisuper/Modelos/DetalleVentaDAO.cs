using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Minisuper.Datos
{
    public class DetalleVentaDAO
    {
        Conexion conexion = new Conexion();

        public void RegistrarDetalle(
            int ventaId,
            int productoId,
            int cantidad,
            decimal precio)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                INSERT INTO detalle_ventas
                (
                    venta_id,
                    producto_id,
                    cantidad,
                    precio_unitario
                )
                VALUES
                (
                    @venta,
                    @producto,
                    @cantidad,
                    @precio
                )";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@venta", ventaId);
                    cmd.Parameters.AddWithValue("@producto", productoId);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precio);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
