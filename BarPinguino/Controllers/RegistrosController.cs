using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using EVA2TI_BarPinguino.Services;


namespace EVA2TI_BarPinguino.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly AppDataContext _context;
        private AuthService _authService;
        public RegistrosController(AppDataContext context)
        {
            _context = context;
            _authService = new AuthService(context);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult RegistroUserEmpleado()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserRegistrado(Usuarios usuario)
        {
            await _authService.RegisterUser(usuario);

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
            try
            {
                var result = _authService.ValidateLogin(credencial, clave);

                if (!result) throw new Exception();

                var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credencial));
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario!.Nombre),
                    new Claim("CredencialVendedor", usuario.CredencialVendedor.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal, new AuthenticationProperties { IsPersistent = false });

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Error = "Credenciales incorrectas.";
                return View();
            }
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
    }
}
