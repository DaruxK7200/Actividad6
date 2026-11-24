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

        public int RegistrarVenta(DateTime fecha, decimal total)
        {
            int ventaId = 0;

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                INSERT INTO ventas(fecha,total)
                VALUES(@fecha,@total)
                RETURNING id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@total", total);

                    ventaId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return ventaId;
        }
    }
}
