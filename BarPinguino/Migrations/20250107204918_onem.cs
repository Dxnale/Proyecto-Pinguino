using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class onem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frecuente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio_original = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio_descuento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.SKU);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Giro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    razon_social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    datos_bancarios = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fono = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Credencial_vendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoDeUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Credencial_vendedor);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Sku = table.Column<int>(type: "int", nullable: false),
                    Provedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    Stock_critico = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    Informe_stock = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_Stock_Descuentos_Sku",
                        column: x => x.Sku,
                        principalTable: "Descuentos",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Proveedores_Provedor",
                        column: x => x.Provedor,
                        principalTable: "Proveedores",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Num_Boleta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Credencial_v = table.Column<int>(type: "int", nullable: false),
                    Credencial_vendedor = table.Column<int>(type: "int", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    cliente_rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPedido = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Num_Boleta);
                    table.ForeignKey(
                        name: "FK_Venta_Clientes_cliente_rut",
                        column: x => x.cliente_rut,
                        principalTable: "Clientes",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Usuarios_Credencial_vendedor",
                        column: x => x.Credencial_vendedor,
                        principalTable: "Usuarios",
                        principalColumn: "Credencial_vendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Finanzas",
                columns: table => new
                {
                    I_stock = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Informe_stock = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gasto = table.Column<int>(type: "int", nullable: false),
                    ingreso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    n_documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tipo_documento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Num_Boleta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finanzas", x => x.I_stock);
                    table.ForeignKey(
                        name: "FK_Finanzas_Stock_Informe_stock",
                        column: x => x.Informe_stock,
                        principalTable: "Stock",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Finanzas_Venta_n_documento",
                        column: x => x.n_documento,
                        principalTable: "Venta",
                        principalColumn: "Num_Boleta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finanzas_Informe_stock",
                table: "Finanzas",
                column: "Informe_stock");

            migrationBuilder.CreateIndex(
                name: "IX_Finanzas_n_documento",
                table: "Finanzas",
                column: "n_documento");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Provedor",
                table: "Stock",
                column: "Provedor");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_cliente_rut",
                table: "Venta",
                column: "cliente_rut");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Credencial_vendedor",
                table: "Venta",
                column: "Credencial_vendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finanzas");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
