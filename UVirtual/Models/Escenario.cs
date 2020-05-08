using System;
using System.Collections.Generic;

namespace UVirtual.Models
{
    public class Escenario
    {
        /*
        [Key]
        public int llave { get; set; }
        */
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int NotaMeta { get; set; }
        public int EmocionMeta { get; set; }
        public int TiempoMeta { get; set; }
        public Boolean Estado { get; set; }

        public ICollection<Rol> Roles { get; set; }

    }
}
