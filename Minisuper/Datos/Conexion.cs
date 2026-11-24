using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Minisuper.Datos
{
    public class Conexion
    {
        private string cadenaConexion =
            "Host=localhost;Port=5432;Database=minisuper;Username=postgres;Password=niasu";

        public NpgsqlConnection ObtenerConexion()
        {
            return new NpgsqlConnection(cadenaConexion);
        }
    }
}

