using DirectorioVentas.Domain;
using Microsoft.EntityFrameworkCore;

namespace DirectorioVentas.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasMany(p => p.Facturas)
                .WithOne(f => f.Persona)
                .HasForeignKey(f => f.PersonaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
