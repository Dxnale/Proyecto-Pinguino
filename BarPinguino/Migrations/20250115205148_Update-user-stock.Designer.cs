﻿// <auto-generated />
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20250115205148_Update-user-stock")]
    partial class Updateuserstock
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Clientes", b =>
                {
                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frecuente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rut");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Rut = "11111111-1",
                            Apellido = "Diaz",
                            Frecuente = "Si",
                            Nombre = "Carlos"
                        },
                        new
                        {
                            Rut = "22222222-2",
                            Apellido = "Soto",
                            Frecuente = "No",
                            Nombre = "Ana"
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Descuentos", b =>
                {
                    b.Property<int>("SKU")
                        .HasColumnType("int");

                    b.Property<string>("PrecioConDescuento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecioOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SKU");

                    b.ToTable("Descuentos");

                    b.HasData(
                        new
                        {
                            SKU = 123,
                            PrecioConDescuento = "450",
                            PrecioOriginal = "500"
                        },
                        new
                        {
                            SKU = 234,
                            PrecioConDescuento = "90",
                            PrecioOriginal = "100"
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Finanzas", b =>
                {
                    b.Property<string>("InformeDeStock")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Gasto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ingreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InformeDeStock");

                    b.ToTable("Finanzas");

                    b.HasData(
                        new
                        {
                            InformeDeStock = "Stock1",
                            Detalles = "Ganancia",
                            Fecha = "2025-01-01",
                            Gasto = 2000m,
                            Ingreso = "3000",
                            NDocumento = "D001",
                            TipoDeDocumento = "Factura"
                        },
                        new
                        {
                            InformeDeStock = "Stock2",
                            Detalles = "Ganancia",
                            Fecha = "2025-01-02",
                            Gasto = 1000m,
                            Ingreso = "1500",
                            NDocumento = "D002",
                            TipoDeDocumento = "Boleta"
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Proveedores", b =>
                {
                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DatosBanco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fono")
                        .HasColumnType("int");

                    b.Property<string>("Giro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rut");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            Rut = "33333333-3",
                            DatosBanco = "Banco1",
                            Direccion = "Calle Falsa 123",
                            Fono = 12345678,
                            Giro = "Bebidas",
                            RazonSocial = "Coke"
                        },
                        new
                        {
                            Rut = "44444444-4",
                            DatosBanco = "Banco2",
                            Direccion = "Calle Verdadera 456",
                            Fono = 87654321,
                            Giro = "Licer",
                            RazonSocial = "FoodInc"
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Stock", b =>
                {
                    b.Property<int>("SKU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SKU"));

                    b.Property<int>("CantidadStock")
                        .HasColumnType("int");

                    b.Property<string>("InformeDeStock")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Proveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StockCritico")
                        .HasColumnType("int");

                    b.HasKey("SKU");

                    b.HasIndex("Proveedor");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            SKU = 123,
                            CantidadStock = 100,
                            InformeDeStock = "Suficiente",
                            NombreProducto = "Ron blanco",
                            Precio = 500m,
                            Proveedor = "33333333-3",
                            StockCritico = 10
                        },
                        new
                        {
                            SKU = 234,
                            CantidadStock = 50,
                            InformeDeStock = "Bajo",
                            NombreProducto = "Agua mineral",
                            Precio = 100m,
                            Proveedor = "44444444-4",
                            StockCritico = 5
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Usuarios", b =>
                {
                    b.Property<int>("CredencialVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CredencialVendedor"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CredencialVendedor");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CredencialVendedor = 111,
                            Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            Correo = "javier.nieves@alumnos.ipleones.cl",
                            Nombre = "Juan Perez",
                            TipoUsuario = "Admin"
                        },
                        new
                        {
                            CredencialVendedor = 222,
                            Clave = "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589",
                            Correo = "benjamin.sequeida@alumnos.ipleones.cl",
                            Nombre = "Maria Lopez",
                            TipoUsuario = "Ventas"
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Venta", b =>
                {
                    b.Property<string>("NumBoleta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteRut")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CredencialVendedor")
                        .HasColumnType("int");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalDelPedido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NumBoleta");

                    b.HasIndex("ClienteRut");

                    b.HasIndex("CredencialVendedor");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            NumBoleta = "B001",
                            ClienteRut = "11111111-1",
                            CredencialVendedor = 111,
                            Detalles = "Compra de Mojito",
                            TotalDelPedido = 5000m
                        },
                        new
                        {
                            NumBoleta = "B002",
                            ClienteRut = "22222222-2",
                            CredencialVendedor = 222,
                            Detalles = "Compra de Daikiri",
                            TotalDelPedido = 1000m
                        });
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Descuentos", b =>
                {
                    b.HasOne("EVA2TI_BarPinguino.Models.Stock", "Stock")
                        .WithOne()
                        .HasForeignKey("EVA2TI_BarPinguino.Models.Descuentos", "SKU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Stock", b =>
                {
                    b.HasOne("EVA2TI_BarPinguino.Models.Proveedores", "ProveedorNavigation")
                        .WithMany("Stocks")
                        .HasForeignKey("Proveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProveedorNavigation");
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Venta", b =>
                {
                    b.HasOne("EVA2TI_BarPinguino.Models.Clientes", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteRut")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVA2TI_BarPinguino.Models.Usuarios", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("CredencialVendedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Clientes", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Proveedores", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("EVA2TI_BarPinguino.Models.Usuarios", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
