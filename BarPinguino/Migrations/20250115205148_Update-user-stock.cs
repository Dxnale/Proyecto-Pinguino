using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class Updateuserstock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "Stocks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "SKU",
                keyValue: 123,
                column: "NombreProducto",
                value: "Ron blanco");

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "SKU",
                keyValue: 234,
                column: "NombreProducto",
                value: "Agua mineral");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                column: "Correo",
                value: "javier.nieves@alumnos.ipleones.cl");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                column: "Correo",
                value: "benjamin.sequeida@alumnos.ipleones.cl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "Stocks");
        }
    }
}
