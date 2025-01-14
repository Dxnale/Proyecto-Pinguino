using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace EVA2TI_BarPinguino.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly AppDataContext _context;
        public RegistrosController(AppDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult RegistroUserEmpleado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegistrado(Usuarios usuario)
        {
            string hashedPassword = HashPassword(usuario.Clave);
            var newUser = new Usuarios
            {
                CredencialVendedor = usuario.CredencialVendedor,
                Clave = hashedPassword,
                Nombre = usuario.Nombre,
                TipoUsuario = usuario.TipoUsuario
            };
            _context.Usuarios.Add(newUser);
            _context.SaveChanges();

            if (usuario.CredencialVendedor != 0) return View("UserRegistrado", usuario);

            ViewData["Error"] = "Error al registrar usuario";
            return View();
        }
        [HttpGet]
        public IActionResult RegistrarUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrado(Clientes clientes)
        {

            var newuser = new Clientes
            {
                Rut = clientes.Rut,
                Nombre = clientes.Nombre,
                Apellido = clientes.Apellido,
                Frecuente = clientes.Frecuente
            };
            _context.Clientes.Add(newuser);
            _context.SaveChanges();


            return View("Registrado", clientes);
        }

        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Consulta(string txtRut)
        {
            var cl = _context.Clientes.FirstOrDefault(c => c.Rut == txtRut);
            if (cl != null)
            {
                ViewBag.ShowModal = true;
                return View(cl);
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string credencial, string clave)
        {
            // Buscar el usuario en la base de datos
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Clave == HashPassword(clave));

            // Verificar si el usuario existe y la clave es correcta
            if (usuario != null && usuario.CredencialVendedor == int.Parse(credencial))
            {
                // Crear la cookie con información del usuario
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("CredencialVendedor", usuario.CredencialVendedor.ToString()),
                    new Claim("TipoUsuario", usuario.TipoUsuario)
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal);

                return RedirectToAction("Index", "Home"); // Redirigir al Home
            }
            // Si las credenciales son incorrectas, retornar la vista de login
            ViewBag.Error = "Credenciales incorrectas. Por favor, intente nuevamente. "+credencial+clave;
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Registros");
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}
