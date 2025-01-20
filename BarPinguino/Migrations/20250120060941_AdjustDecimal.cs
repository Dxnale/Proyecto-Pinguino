using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA2TI_BarPinguino.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
