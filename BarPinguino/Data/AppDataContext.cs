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
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<Finanzas> Finanzas { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(tb =>
            {
                tb.HasKey(c => c.Rut);

                tb.Property(c => c.Nombre).HasMaxLength(50).IsRequired();
                tb.Property(c => c.Apellido).HasMaxLength(50).IsRequired();
                tb.Property(c => c.Frecuente).HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Clientes>().ToTable("Clientes");

            modelBuilder.Entity<Usuarios>(tb =>
            {
                tb.HasKey(u => u.Credencial_vendedor);

                tb.Property(u => u.Credencial_vendedor).UseIdentityColumn();

                tb.Property(u => u.clave).HasMaxLength(50).IsRequired();
                tb.Property(u => u.Nombre).HasMaxLength(50).IsRequired();
                tb.Property(u => u.TipoDeUsuario).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");

            modelBuilder.Entity<Venta>(tb =>
            {
                tb.HasKey(v => v.Num_Boleta);

                tb.Property(v => v.Credencial_v).IsRequired();
                tb.Property(v => v.Detalles).HasMaxLength(200).IsRequired();
                tb.Property(v => v.cliente_rut).IsRequired();
                tb.Property(v => v.TotalPedido).IsRequired();

                tb.HasOne(v => v.Clientes)
                  .WithMany(c => c.Venta)
                  .HasForeignKey(v => v.cliente_rut)
                  .HasPrincipalKey(c => c.Rut);
            });

            modelBuilder.Entity<Venta>().ToTable("Venta");

            modelBuilder.Entity<Descuentos>(tb =>
            {
                tb.HasKey(d => d.SKU);

                tb.Property(d => d.Precio_original).HasMaxLength(50).IsRequired();
                tb.Property(d => d.Precio_descuento).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<Descuentos>().ToTable("Descuentos");

            modelBuilder.Entity<Finanzas>(tb =>
            {
                tb.HasKey(f => f.I_stock);

                tb.Property(f => f.Fecha).IsRequired();
                tb.Property(f => f.Gasto).IsRequired();
                tb.Property(f => f.ingreso).HasMaxLength(50).IsRequired();
                tb.Property(f => f.Detalles).HasMaxLength(200).IsRequired();
                
                tb.Property(f => f.tipo_documento).HasMaxLength(50).IsRequired();

                tb.HasOne(f => f.Venta)
                  .WithMany(v => v.Finanzas)
                  .HasForeignKey(f => f.n_documento) // Clave externa
                  .HasPrincipalKey(v => v.Num_Boleta); // Clave primaria
            });

            modelBuilder.Entity<Finanzas>().ToTable("Finanzas");

            modelBuilder.Entity<Proveedores>(tb =>
            {
                tb.HasKey(p => p.Rut);

                tb.Property(p => p.Giro).HasMaxLength(50).IsRequired();
                tb.Property(p => p.razon_social).HasMaxLength(100).IsRequired();
                tb.Property(p => p.datos_bancarios).HasMaxLength(100).IsRequired();
                tb.Property(p => p.Fono).IsRequired();
                tb.Property(p => p.direccion).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Proveedores>().ToTable("Proveedores");

            modelBuilder.Entity<Stock>(tb =>
            {
                tb.HasKey(s => s.Sku);

                tb.Property(s => s.Provedor);
                tb.Property(s => s.stock).IsRequired();
                tb.Property(s => s.Stock_critico).IsRequired();
                tb.Property(s => s.precio).IsRequired();
                tb.Property(s => s.Informe_stock).HasMaxLength(50).IsRequired();

                tb.HasOne(s => s.Proveedores)
                  .WithMany(p => p.Stock)
                  .HasForeignKey(s => s.Provedor) 
                  .HasPrincipalKey(p => p.Rut); 
            });

            modelBuilder.Entity<Stock>().ToTable("Stock");
        }

    }
}
