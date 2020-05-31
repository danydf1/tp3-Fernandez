using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class carrito
    {
        public int ID { get; set; }
        public Producto articulo { get; set; }
        public int CantidadProductos { get; set; }
        public decimal precioUniario { get; set; }
        public decimal Total { get; set; }
    }
}
