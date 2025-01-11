using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EVA2TI_BarPinguino.Controllers
{
    public class TallerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Login(string login, string password, string checker)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || checker != "on")
            {
                return View();
            }

            SqlQueryBuilder sqlBuilder = new();
            using (SqlDataReader reader = await sqlBuilder.SetQuery("SELECT Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel FROM danielTorrealba_PERFILES WHERE Rut = @Rut AND Clave = @Clave")
                                                           .AddParameter("@Rut", login)
                                                           .AddParameter("@Clave", password)
                                                           .ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string nombre = reader["Nombre"].ToString();
                    nombre = char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower();
                    
                    int nivel = Convert.ToInt32(reader["Nivel"]);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, nombre),
                        new Claim(ClaimTypes.Role, nivel == 1 ? "Admin" : "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
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
