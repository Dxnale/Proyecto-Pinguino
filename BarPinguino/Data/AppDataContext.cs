using Microsoft.EntityFrameworkCore;
using EVA2TI_BarPinguino.Models;

namespace EVA2TI_BarPinguino.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(tb => 
            {
                tb.HasKey(c => c.Rut);

                tb.Property(c => c.Rut).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.Property(c => c.Nombre).HasMaxLength(50).IsRequired();
                tb.Property(c => c.Apellido).HasMaxLength(50).IsRequired();
                tb.Property(c => c.Frecuente).HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Clientes>().ToTable("Clientes");
        }
    }
}
