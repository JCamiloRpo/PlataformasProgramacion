using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public class Unidad_Residencial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Boolean Estado { get; set; }
        public int CiudadID { get; set; }

        public Ciudad Ciudad { get; set; }
        public ICollection<Apartamento> Apartamentos { get; set; }
    }
}
