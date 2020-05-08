using System;
using System.Collections.Generic;

namespace UVirtual.Models
{
    public class Situacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Boolean Inicio { get; set; }
        public Boolean Estado { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
        public ICollection<Tarjeta> Tarjetas { get; set; }
    }
}
