using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frecuente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "Finanzas",
                columns: table => new
                {
                    InformeDeStock = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gasto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ingreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finanzas", x => x.InformeDeStock);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Giro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatosBanco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CredencialVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CredencialVendedor);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CantidadStock = table.Column<int>(type: "int", nullable: false),
                    StockCritico = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InformeDeStock = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.SKU);
                    table.ForeignKey(
                        name: "FK_Stocks_Proveedores_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    NumBoleta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CredencialVendedor = table.Column<int>(type: "int", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteRut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalDelPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.NumBoleta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteRut",
                        column: x => x.ClienteRut,
                        principalTable: "Clientes",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_CredencialVendedor",
                        column: x => x.CredencialVendedor,
                        principalTable: "Usuarios",
                        principalColumn: "CredencialVendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false),
                    PrecioOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioConDescuento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.SKU);
                    table.ForeignKey(
                        name: "FK_Descuentos_Stocks_SKU",
                        column: x => x.SKU,
                        principalTable: "Stocks",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Rut", "Apellido", "Frecuente", "Nombre" },
                values: new object[,]
                {
                    { "11111111-1", "Diaz", "Si", "Carlos" },
                    { "22222222-2", "Soto", "No", "Ana" }
                });

            migrationBuilder.InsertData(
                table: "Finanzas",
                columns: new[] { "InformeDeStock", "Detalles", "Fecha", "Gasto", "Ingreso", "NDocumento", "TipoDeDocumento" },
                values: new object[,]
                {
                    { "Stock1", "Ganancia", "2025-01-01", 2000m, "3000", "D001", "Factura" },
                    { "Stock2", "Ganancia", "2025-01-02", 1000m, "1500", "D002", "Boleta" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Rut", "DatosBanco", "Direccion", "Fono", "Giro", "RazonSocial" },
                values: new object[,]
                {
                    { "33333333-3", "Banco1", "Calle Falsa 123", 12345678, "Bebidas", "Coke" },
                    { "44444444-4", "Banco2", "Calle Verdadera 456", 87654321, "Licer", "FoodInc" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CredencialVendedor", "Clave", "Nombre", "TipoUsuario" },
                values: new object[,]
                {
                    { 111, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Juan Perez", "Admin" },
                    { 222, "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589", "Maria Lopez", "Ventas" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "SKU", "CantidadStock", "InformeDeStock", "Precio", "Proveedor", "StockCritico" },
                values: new object[,]
                {
                    { 123, 100, "Suficiente", 500m, "33333333-3", 10 },
                    { 234, 50, "Bajo", 100m, "44444444-4", 5 }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "NumBoleta", "ClienteRut", "CredencialVendedor", "Detalles", "TotalDelPedido" },
                values: new object[,]
                {
                    { "B001", "11111111-1", 111, "Compra de Mojito", 5000m },
                    { "B002", "22222222-2", 222, "Compra de Daikiri", 1000m }
                });

            migrationBuilder.InsertData(
                table: "Descuentos",
                columns: new[] { "SKU", "PrecioConDescuento", "PrecioOriginal" },
                values: new object[,]
                {
                    { 123, "450", "500" },
                    { 234, "90", "100" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Proveedor",
                table: "Stocks",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteRut",
                table: "Ventas",
                column: "ClienteRut");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CredencialVendedor",
                table: "Ventas",
                column: "CredencialVendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Finanzas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
