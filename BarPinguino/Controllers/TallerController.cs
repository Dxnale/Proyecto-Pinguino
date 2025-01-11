using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EVA2TI_BarPinguino.Controllers
{
    public class TallerController : Controller
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=taller_eva3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        [HttpGet]
        public async Task<IActionResult> Login(string login, string password, string checker)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || checker != "on")
            {
                return View();
            }

            string rut = login;
            string pass = password;

            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel FROM danielTorrealba_PERFILES WHERE Rut = @Rut AND Clave = @Clave";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Rut", rut);
                command.Parameters.AddWithValue("@Clave", pass);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader["Nombre"]?.ToString();
                    int nivel = Convert.ToInt32(reader["Nivel"]);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, nombre),
                        new Claim(ClaimTypes.Role, nivel == 1 ? "Admin" : "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false
                    };

                    ViewBag.nombre = nombre;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.invalidCredentialsMessage = $"Credenciales Invalidas";
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.invalidCredentialsMessage = "";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Vista2()
        {
            return View();
        }

        public IActionResult Vista4() {

            return View();
        }
    }
}
