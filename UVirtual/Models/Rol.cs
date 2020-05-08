using System;
using System.Collections.Generic;

namespace UVirtual.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Estado { get; set; }
        public int EscenarioID { get; set; }

        public Escenario Escenario { get; set; }
        public ICollection<Personaje> Personajes { get; set; }
    }
}
