using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EVA2TI_BarPinguino.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EVA2TI_BarPinguino.Controllers
{
    public class Eva3Controller : BaseController
    {
        [HttpGet]
        public IActionResult Frases()
        {

            SqlQueryBuilder sqlBuilder = new();
            string query = "SELECT TOP 1 frase FROM danielTorrealba_FRASES ORDER BY NEWID();";
            using (SqlDataReader reader = sqlBuilder.SetQuery(query).ExecuteReaderAsync().Result)
            {
                while (reader.Read())
                {
                    ViewBag.Frase = reader["frase"].ToString();
                }
            }
            return ViewIfIsRole(null,"User", "Admin");
        }
        public async Task<IActionResult> VerPerfiles()
        {
            List<Perfil> perfiles = new List<Perfil>();

            SqlQueryBuilder sqlBuilder = new SqlQueryBuilder();
            string query = "SELECT Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel FROM danielTorrealba_PERFILES";
            using (SqlDataReader reader = await sqlBuilder.SetQuery(query).ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    perfiles.Add(new Perfil
                    {
                        Rut = reader["Rut"].ToString() ?? "",
                        Nombre = reader["Nombre"].ToString() ?? "",
                        ApPat = reader["ApPat"].ToString() ?? "",
                        ApMat = reader["ApMat"].ToString() ?? "",
                        Edad = Convert.ToInt32(reader["Edad"]),
                        Clave = reader["Clave"].ToString() ?? "",
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                    });
                }
            }
            return ViewIfIsRole(perfiles, "Admin");
        }

        public IActionResult AgregarPerfil()
        {
            return ViewIfIsRole(null, "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> AgregarPerfil(string rut, string nombre, string apPat, string apMat, string edad, string nivel)
        {
            SqlQueryBuilder sqlBuilder = new();
            string query = "INSERT INTO danielTorrealba_PERFILES (Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel) VALUES (@Rut, @Nombre, @ApPat, @ApMat, @Edad, CONCAT(LEFT(@Nombre, 1), LEFT(@ApPat, 1), LEFT(@ApMat, 1), @Rut), @Nivel);";
            await sqlBuilder.SetQuery(query)
                            .AddParameter("@Rut", rut)
                            .AddParameter("@Nombre", nombre)
                            .AddParameter("@ApPat", apPat)
                            .AddParameter("@ApMat", apMat)
                            .AddParameter("@Edad", edad)
                            .AddParameter("@Nivel", nivel)
                            .ExecuteNonQueryAsync();
            return ViewIfIsRole(null, "Admin");
        }

        public IActionResult ModificarPerfil()
        {
            ViewBag.Rut = null;
            return ViewIfIsRole(null, "Admin");
        }

        [HttpGet]
        public IActionResult ModificarPerfil(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut))
            {
                ModelState.AddModelError("", "El RUT es obligatorio.");
                return ViewIfIsRole(null, "Admin");
            }

            SqlQueryBuilder sqlBuilder = new();
            string query = "SELECT Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel FROM danielTorrealba_PERFILES WHERE Rut = @Rut";
            using (SqlDataReader reader = sqlBuilder.SetQuery(query)
                                                    .AddParameter("@Rut", rut)
                                                    .ExecuteReaderAsync().Result)
            {
                while (reader.Read())
                {
                    ViewBag.Rut = reader["Rut"].ToString();
                    ViewBag.Nombre = reader["Nombre"].ToString();
                    ViewBag.ApPat = reader["ApPat"].ToString();
                    ViewBag.ApMat = reader["ApMat"].ToString();
                    ViewBag.Edad = reader["Edad"].ToString();
                    ViewBag.Nivel = reader["Nivel"].ToString();
                }
            }
            return ViewIfIsRole(null, "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPerfil(string rut, string nombre, string apPat, string apMat, string edad, string nivel)
        {
            SqlQueryBuilder sqlBuilder = new();
            string query = "UPDATE danielTorrealba_PERFILES SET Nombre = @Nombre, ApPat = @ApPat, ApMat = @ApMat, Edad = @Edad, Nivel = @Nivel WHERE Rut = @Rut";
            await sqlBuilder.SetQuery(query)
                            .AddParameter("@Rut", rut)
                            .AddParameter("@Nombre", nombre)
                            .AddParameter("@ApPat", apPat)
                            .AddParameter("@ApMat", apMat)
                            .AddParameter("@Edad", edad)
                            .AddParameter("@Nivel", nivel)
                            .ExecuteNonQueryAsync();
            return ViewIfIsRole(null, "Admin");
        }

        public IActionResult EliminarPerfil()
        {
            return ViewIfIsRole(null, "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPerfil(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut))
            {
                ModelState.AddModelError("", "El RUT es obligatorio.");
                return ViewIfIsRole(null, "Admin");
            }

            SqlQueryBuilder sqlBuilder = new();
            string query = "DELETE FROM danielTorrealba_PERFILES WHERE Rut = @Rut";

            try
            {
                await sqlBuilder.SetQuery(query)
                                .AddParameter("@Rut", rut)
                                .ExecuteNonQueryAsync();

                ViewBag.Message = "Usuario eliminado correctamente.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Ocurrió un error al intentar eliminar el usuario: " + ex.Message;
            }

            return ViewIfIsRole(null, "Admin");
        }

    }
}
