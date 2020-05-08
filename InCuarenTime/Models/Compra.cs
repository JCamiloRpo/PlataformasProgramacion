using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public partial class Compra
    {
        public int Id { get; set; }
        public Boolean Estado { get; set; }
        public int Cantidad { get; set; }
        public int MercadoID { get; set; }
        public int ProductoID { get; set; }

        public Mercado Mercado { get; set; }
        public Producto Productos { get; set; }

    }
}
