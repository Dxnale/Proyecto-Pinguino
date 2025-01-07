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

                tb.Property(c => c.Rut).UseIdentityColumn();

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

            modelBuilder.Entity<Venta>(static tb =>
            {
                tb.HasKey(v => v.Num_Boleta);

                tb.Property(v => v.Num_Boleta).UseIdentityColumn();

                tb.Property(v => v.Credencial_v).IsRequired();
                tb.Property(v => v.Detalles).HasMaxLength(200).IsRequired();
                tb.Property(v => v.cliente_rut).IsRequired();
                tb.Property(v => v.TotalPedido).IsRequired();
                
            });

            modelBuilder.Entity<Venta>().ToTable("Venta");

            modelBuilder.Entity<Descuentos>(tb =>
            {
                tb.HasKey(d => d.Sku);

                tb.Property(d => d.Sku).UseIdentityColumn();

                tb.Property(d => d.Precio_original).HasMaxLength(50).IsRequired();
                tb.Property(d => d.Precio_descuento).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<Descuentos>().ToTable("Descuentos");

            modelBuilder.Entity<Finanzas>(tb =>
            {
                tb.HasKey(f => f.Informe_stock);

                tb.Property(f => f.Informe_stock).UseIdentityColumn();

                tb.Property(f => f.Fecha).IsRequired();
                tb.Property(f => f.Gasto).IsRequired();
                tb.Property(f => f.ingreso).HasMaxLength(50).IsRequired();
                tb.Property(f => f.Detalles).HasMaxLength(200).IsRequired();
                tb.Property(f => f.n_documento).HasMaxLength(50).IsRequired();
                tb.Property(f => f.tipo_documento).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Finanzas>().ToTable("Finanzas");

            modelBuilder.Entity<Proveedores>(tb =>
            {
                tb.HasKey(p => p.Rut);

                tb.Property(p => p.Rut).UseIdentityColumn();

                tb.Property(p => p.Giro).HasMaxLength(50).IsRequired();
                tb.Property(p => p.razon_social).HasMaxLength(100).IsRequired();
                tb.Property(p => p.datos_bancarios).HasMaxLength(100).IsRequired();
                tb.Property(p => p.Fono).IsRequired();
                tb.Property(p => p.direccion).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Proveedores>().ToTable("Proveedores");

            modelBuilder.Entity<Stock>(tb =>
            {
                tb.HasKey(s => s.SKu);

                tb.Property(s => s.SKu).UseIdentityColumn();

                tb.Property(s => s.Provedor).HasMaxLength(50).IsRequired();
                tb.Property(s => s.stock).IsRequired();
                tb.Property(s => s.Stock_critico).IsRequired();
                tb.Property(s => s.precio).IsRequired();
                tb.Property(s => s.Informe_stock).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Stock>().ToTable("Stock");
        }

    }
}
