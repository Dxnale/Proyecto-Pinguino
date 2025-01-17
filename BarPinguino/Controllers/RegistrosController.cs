using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace EVA2TI_BarPinguino.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly AppDataContext _context;
        public RegistrosController(AppDataContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult RegistroUserEmpleado()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult UserRegistrado(Usuarios usuario)
        {
            string hashedPassword = HashPassword(usuario.Clave);
            var newUser = new Usuarios
            {
                CredencialVendedor = usuario.CredencialVendedor,
                Clave = hashedPassword,
                Nombre = usuario.Nombre,
                TipoUsuario = usuario.TipoUsuario,
                Correo = usuario.Correo
            };
            _context.Usuarios.Add(newUser);
            _context.SaveChanges();

            if (usuario.CredencialVendedor != 0) return View("UserRegistrado", usuario);

            ViewData["Error"] = "Error al registrar usuario";
            return View();
        }
        [Authorize(Roles = "Admin,Ventas")]
        [HttpGet]
        public IActionResult RegistrarUser()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Ventas")]
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
        [Authorize(Roles = "Admin,Ventas")]
        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Ventas")]
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
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string credencial, string clave)
        {
            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Clave == HashPassword(clave));

            
            if (usuario != null && usuario.CredencialVendedor == int.Parse(credencial))
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("CredencialVendedor", usuario.CredencialVendedor.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal, new AuthenticationProperties { IsPersistent = false});

                return RedirectToAction("Index", "Home"); 
            }
         
            ViewBag.Error = "Credenciales incorrectas. Por favor, intente nuevamente. ";
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";
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
