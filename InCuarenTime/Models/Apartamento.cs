using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public class Apartamento
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Bloque { get; set; }
        public Boolean Estado { get; set; }
        public int Unidad_ResidencialID { get; set; }

        public Unidad_Residencial Unidad_Residencial { get; set; }
        public Propietario Propietario { get; set; }
    }
}
