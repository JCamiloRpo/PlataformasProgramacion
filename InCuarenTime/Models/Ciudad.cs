using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InCuarenTime.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Estado { get; set; }
        public int DepartamentoID { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Unidad_Residencial> Unidad_Residenciales { get; set; }
    }
}
