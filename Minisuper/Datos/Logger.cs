using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Minisuper.Datos
{
    public static class Logger
    {
        public static void Registrar(Exception ex)
        {
            File.AppendAllText(
                "errores_sistema.log",
                $"[{DateTime.Now}] " +
                $"{ex.GetType().Name}: " +
                $"{ex.Message}\n" +
                $"{ex.StackTrace}\n" +
                "----------------------\n");
        }
    }
}
