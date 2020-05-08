using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public class Mercado
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Boolean Estado { get; set; }
        public int PropietarioID { get; set; }

        public Propietario Propietario { get; set; }
        public Compra Compra { get; set; }
    }
}
