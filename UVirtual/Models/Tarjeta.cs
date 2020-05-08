using System.ComponentModel.DataAnnotations.Schema;

namespace UVirtual.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int PersonajeID { get; set; }
        public int SituacionID { get; set; }
        public int RespuestaID { get; set; }
        [ForeignKey("Respuesta2")]
        public int Respuesta2ID { get; set; }

        public Personaje Personaje { get; set; }
        public Situacion Situacion { get; set; }
        public Respuesta Respuesta { get; set; }
        [ForeignKey("Respuesta2ID")]
        public Respuesta Respuesta2 { get; set; }
    }
}
