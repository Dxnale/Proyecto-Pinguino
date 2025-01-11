using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EVA2TI_BarPinguino.Models;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
            return ViewIfIsRole(null, "User", "Admin");
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
            if (string.IsNullOrWhiteSpace(rut))
            {
                ViewBag.Message("", "El RUT ingresado no es válido.");
                return ViewIfIsRole(null, "Admin");
            }

            rut = ValidadorRUT(rut);
            
            string apiURL = $"https://api.luyanez.cl/?rut={rut}";
            using HttpClient client = new HttpClient();
            JObject response = JObject.Parse(await client.GetStringAsync(apiURL));

            if (response["status"]?.ToString() != "200" || response["result"]?[0]?["estado"]?.ToString() == "ListaNegra")
            {
                ViewBag.Message = "El RUT ingresado no esta validado por el cliente.";
                return ViewIfIsRole(null, "Admin");
            }

            string frase = response["result"][0]["frase"].ToString();


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
            SqlQueryBuilder secondBuilder = new();
            await secondBuilder.SetQuery("INSERT INTO danielTorrealba_FRASES (frase) VALUES (@frase)")
                .AddParameter("@frase", frase)
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

        private string ValidadorRUT(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            bool rutValido = Regex.IsMatch(rut, @"^\d{1,10}[kK]?$");

            rutValido = ValidarRut(rut);

            if (!rutValido)
            {
                return "";
            }

            return rut;

        }

        public static bool ValidarRut(string Rut)
        {
            Rut = Rut.Replace(".", "").Replace("-", "").ToUpper(); //quita puntos y guiones y pasa a mayusculas si el rut es menor a 9 digitos agrega un 0 al inicio

            if (Rut.Length <= 2 || Rut.Length > 9) return false; //si el rut no es del largo correcto corta la ejecucion

            Rut = Rut.Length < 9 ? "0" + Rut : Rut; //si el rut es menor a 9 digitos agrega un 0 al inicio

            string digito = ValidarDigito(Rut);
            return Rut[Rut.Length - 1].ToString().Equals(digito);

        }

        public static string ValidarDigito(string Rut)
        {
            int[] digitosAlgoritmo = [3, 2, 7, 6, 5, 4, 3, 2];

            int suma = 0;

            for (int i = 0; i < Rut.Length - 1; i++)
            {
                suma += digitosAlgoritmo[i] * Int32.Parse(Rut[i].ToString()); //multiplica cada digito por el valor del array de digitos constantes y lo suma a la variable suma
            }

            int residuo = suma % 11;
            int resultado = 11 - residuo;

            return resultado == 10 ? "K" : resultado == 11 ? "0" : resultado.ToString(); //si el resultado es 10 retorna K, si es 11 retorna 0, si no simplemente retorna el digito resultante
        }

    }
}
