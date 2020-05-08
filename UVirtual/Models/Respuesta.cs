using System;
using System.Collections.Generic;

namespace UVirtual.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public Boolean Estado { get; set; }
        public int NotaCambio { get; set; }
        public int EmocionCambio { get; set; }
        public int TiempoCambio { get; set; }
        public int SituacionID { get; set; }

        public Situacion Situacion { get; set; }
    }
}
