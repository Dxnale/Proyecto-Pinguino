using Microsoft.EntityFrameworkCore;
using EVA2TI_BarPinguino.Models;

namespace EVA2TI_BarPinguino.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Finanzas> Finanzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.ProveedorNavigation)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.Proveedor)
                .HasPrincipalKey(p => p.Rut);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Ventas)
                .HasForeignKey(v => v.CredencialVendedor);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteRut);

            modelBuilder.Entity<Descuentos>()
                .HasOne(d => d.Stock)
                .WithOne()
                .HasForeignKey<Descuentos>(d => d.SKU);

            // Seed data
            modelBuilder.Entity<Stock>().HasData(
                new Stock { SKU = 123, NombreProducto ="Ron blanco", Proveedor = "33333333-3", CantidadStock = 100, StockCritico = 10, Precio = 500, InformeDeStock = "Suficiente" },
                new Stock { SKU = 234, NombreProducto ="Agua mineral" ,Proveedor = "44444444-4", CantidadStock = 50, StockCritico = 5, Precio = 100, InformeDeStock = "Bajo" }
            );
            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios { CredencialVendedor = 111, Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", Nombre = "Juan Perez", Correo ="javier.nieves@alumnos.ipleones.cl" ,TipoUsuario = "Admin" },
                new Usuarios { CredencialVendedor = 222, Clave = "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589", Nombre = "Maria Lopez", Correo ="benjamin.sequeida@alumnos.ipleones.cl" ,TipoUsuario = "Ventas" }
            );

            modelBuilder.Entity<Clientes>().HasData(
                new Clientes { Rut = "11111111-1", Nombre = "Carlos", Apellido = "Diaz", Frecuente = "Si" },
                new Clientes { Rut = "22222222-2", Nombre = "Ana", Apellido = "Soto", Frecuente = "No" }
            );

            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { Rut = "33333333-3", Giro = "Bebidas", RazonSocial = "Coke", DatosBanco = "Banco1", Fono = 12345678, Direccion = "Calle Falsa 123" },
                new Proveedores { Rut = "44444444-4", Giro = "Licer", RazonSocial = "FoodInc", DatosBanco = "Banco2", Fono = 87654321, Direccion = "Calle Verdadera 456" }
            );

            modelBuilder.Entity<Descuentos>().HasData(
                new Descuentos { SKU = 123, PrecioOriginal = "500", PrecioConDescuento = "450" },
                new Descuentos { SKU = 234, PrecioOriginal = "100", PrecioConDescuento = "90" }
            );

            modelBuilder.Entity<Venta>().HasData(
                new Venta { NumBoleta = "B001", CredencialVendedor = 111, Detalles = "Compra de Mojito", ClienteRut = "11111111-1", TotalDelPedido = 5000 },
                new Venta { NumBoleta = "B002", CredencialVendedor = 222, Detalles = "Compra de Daikiri", ClienteRut = "22222222-2", TotalDelPedido = 1000 }
            );

            modelBuilder.Entity<Finanzas>().HasData(
                new Finanzas { InformeDeStock = "Stock1", Fecha = "2025-01-01", Gasto = 2000, Ingreso = "3000", Detalles = "Ganancia", NDocumento = "D001", TipoDeDocumento = "Factura" },
                new Finanzas { InformeDeStock = "Stock2", Fecha = "2025-01-02", Gasto = 1000, Ingreso = "1500", Detalles = "Ganancia", NDocumento = "D002", TipoDeDocumento = "Boleta" }
            );
        }
    }
}
