using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class VentasEnPreparacionNewState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnPreparacion",
                table: "Ventas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "u5q3HQQ4dPynePpEjAq47xW+NMiQi/RLxSsDcu2Qzbw=", "9anlhbr1YSBPECun/Xs6zQ==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "u5q3HQQ4dPynePpEjAq47xW+NMiQi/RLxSsDcu2Qzbw=", "9anlhbr1YSBPECun/Xs6zQ==" });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "NumBoleta",
                keyValue: "B001",
                column: "EnPreparacion",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "NumBoleta",
                keyValue: "B002",
                column: "EnPreparacion",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnPreparacion",
                table: "Ventas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "hUjsCXxPYVTghiv7EdUzvfIAYtv0HXNYVN0D3000MnI=", "it3al8JmV7FM1GbJF8RtRA==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "hUjsCXxPYVTghiv7EdUzvfIAYtv0HXNYVN0D3000MnI=", "it3al8JmV7FM1GbJF8RtRA==" });
        }
    }
}
