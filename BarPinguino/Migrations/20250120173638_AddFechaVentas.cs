using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha",
                table: "Ventas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

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

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "NumBoleta",
                keyValue: "B001",
                column: "Fecha",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "NumBoleta",
                keyValue: "B002",
                column: "Fecha",
                value: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Ventas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "dqpHxzoM8S+0Hu6FTjICoAuHs/Hvwi41B2Ht3yPWPRM=", "80mQB15dh+fm7E4QYtXp8Q==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "dqpHxzoM8S+0Hu6FTjICoAuHs/Hvwi41B2Ht3yPWPRM=", "80mQB15dh+fm7E4QYtXp8Q==" });
        }
    }
}
