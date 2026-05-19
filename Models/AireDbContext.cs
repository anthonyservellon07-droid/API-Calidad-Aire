using Microsoft.EntityFrameworkCore;

namespace CalidadAireAPI.Models
{
    // Clase para manejar la conexion a la base de datos
    public class AireDbContext : DbContext
    {
        public AireDbContext(DbContextOptions<AireDbContext> options) : base(options)
        {
        }

        // Tablas mapeadas a nuestros modelos
        public DbSet<SensorCalidadAire> SensorCalidadAire { get; set; }
        public DbSet<LecturaAire> LecturaAire { get; set; }
        public DbSet<AlertaAire> AlertaAire { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dejo esto por si el profe pide configuraciones extra despues
            // pero por ahora EF Core mapea bien con los nombres de las propiedades (Id, SensorId)
            base.OnModelCreating(modelBuilder);
        }
    }
}