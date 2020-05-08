using System;
using System.Collections.Generic;

namespace UVirtual.Models
{
    public class Personaje
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Estado { get; set; }
        public int RolID { get; set; }

        public Rol Rol { get; set; }
        public ICollection<Tarjeta> Tarjetas { get; set; }
    }
}
