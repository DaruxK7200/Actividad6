using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Minisuper.Modelos;

namespace Minisuper.Datos
{
    public class ProductoDAO
    {
        Conexion conexion = new Conexion();

        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql =
                    "SELECT id, nombre, precio, stock FROM productos ORDER BY nombre";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto producto = new Producto();

                            producto.Id = dr.GetInt32(0);
                            producto.Nombre = dr.GetString(1);
                            producto.Precio = dr.GetDecimal(2);
                            producto.Stock = dr.GetInt32(3);

                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }
    }
}
