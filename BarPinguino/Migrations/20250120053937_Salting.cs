using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class Salting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "WnUx40F6iNe96kd5C5Zaxxrs1siPShtQJhzkRwJ3lco=", "5IZET2m2ny0jDzf3fl9Vdg==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                columns: new[] { "Clave", "PasswordSalt" },
                values: new object[] { "WnUx40F6iNe96kd5C5Zaxxrs1siPShtQJhzkRwJ3lco=", "5IZET2m2ny0jDzf3fl9Vdg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 111,
                column: "Clave",
                value: "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CredencialVendedor",
                keyValue: 222,
                column: "Clave",
                value: "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589");
        }
    }
}
