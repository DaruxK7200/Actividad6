using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minisuper.Modelos
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Vendedor { get; set; }

        public decimal SubtotalBruto { get; set; }

        public decimal PorcentajeDescuento { get; set; }

        public decimal MontoDescuento { get; set; }

        public decimal TotalFinal { get; set; }
        public decimal AplicarDescuento()
        {
            if (PorcentajeDescuento < 0 ||
                PorcentajeDescuento > 20)
            {
                throw new Exception(
                    "Descuento fuera de rango.");
            }

            MontoDescuento =
                SubtotalBruto *
                PorcentajeDescuento / 100;

            TotalFinal =
                SubtotalBruto - MontoDescuento;

            return TotalFinal;
        }
    }

}
