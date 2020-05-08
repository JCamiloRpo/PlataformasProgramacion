using Microsoft.EntityFrameworkCore;
using UVirtual.Models;

namespace UVirtual.Data
{
    public class UVirtualContext : DbContext
    {
        public UVirtualContext(DbContextOptions<UVirtualContext> options) : base(options)
        {
        }

        public DbSet<Escenario> Escenario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<Situacion> Situacion { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Partida> Partida { get; set; }

    }
}
