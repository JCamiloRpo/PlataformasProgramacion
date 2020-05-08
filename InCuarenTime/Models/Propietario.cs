using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public Boolean Estado { get; set; }
        public int ApartamentoID { get; set; }

        public Apartamento Apartamento { get; set; }
        public ICollection<Mercado> Mercados { get; set; }
    }
}
