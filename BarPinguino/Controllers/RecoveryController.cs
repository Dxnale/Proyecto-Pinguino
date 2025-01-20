using System.Security.Claims;
using EVA2TI_BarPinguino.Data;
using EVA2TI_BarPinguino.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class RecoveryController : Controller
    {
        private readonly AppDataContext _context;
        private readonly Correo _correo;
        private readonly ILogger _logger;
        private HasherService _hasherService;
        public RecoveryController(AppDataContext context, Correo correo, ILogger<RecoveryController> logger)
        {
            _context = context;
            _correo = correo;
            _logger = logger;
            _hasherService = new HasherService();
        }
        [HttpPost]
        public async Task<IActionResult> DobleFactor(string codigo)
        {
            var codigoenviado = TempData["clave"]?.ToString();
            var credencial = TempData["credencial"]?.ToString();
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credencial!));

            if (codigoenviado == codigo)
            {
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
            // Si el código no es válido
            ViewBag.Error = "El código de doble factor no es válido.";
            return View();
        }
        public async Task<IActionResult> Recuperacion(string codigo, string passN, string passNdos)
        {
            if (passN == passNdos)
            {
                var codigoenviado = TempData["clave"]?.ToString();
                var credencial = TempData["credencial"]?.ToString();
                var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credencial!));

                var hashResult = _hasherService.HashPassword(passN);
                usuario!.Clave = hashResult.Hash;
                usuario!.PasswordSalt = hashResult.Salt;

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                if (codigoenviado == codigo)
                {
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
            }
            // Si el código no es válido
            ViewBag.Error = "El código de doble factor no es válido.";
            return View();
        }

        public IActionResult EnvioCorreo(string credencial)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credencial));

            // Generar código aleatorio de doble factor
            Random random = new Random();
            string clave = random.Next(1000, 9999).ToString();
            TempData["clave"] = clave;
            TempData["credencial"] = credencial;

            // Enviar correo
            string asunto = "Código de Doble Factor";
            string cuerpoHtml = $@"
        <body style='background-color: #0606271b;'>
            <div>
                <h1 style='color:#f5f5f5;font-family:sans-serif; text-align: center;'>RECUPERACIÓN DE CLAVE</h1>
                <p style='color:#f5f5f5;font-family:sans-serif; text-align: center;'>
                Aquí está tu clave para el acceso: <strong>{clave}</strong>
                </p>
            </div>
        </body>";

            _correo.EnvMail(usuario!.Correo, asunto, cuerpoHtml);

            // Retornar la misma vista y pasar un mensaje de éxito
            ViewBag.SuccessMessage = "Se ha enviado un código de verificación a tu correo.";
            return View("DobleFactor");  // Mantener la vista actual
        }
        public IActionResult EnvioCorreorecu(string credencial)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credencial));

            // Generar código aleatorio de doble factor
            Random random = new Random();
            string clave = random.Next(1000, 9999).ToString();
            TempData["clave"] = clave;
            TempData["credencial"] = credencial;

            // Enviar correo
            string asunto = "Código de Recuperacion";
            string cuerpoHtml = $@"
        <body style='background-color: #0606271b;'>
            <div>
                <h1 style='color:#f5f5f5;font-family:sans-serif; text-align: center;'>RECUPERACIÓN DE CLAVE</h1>
                <p style='color:#f5f5f5;font-family:sans-serif; text-align: center;'>
                Aquí está tu clave para el acceso: <strong>{clave}</strong>
                </p>
            </div>
        </body>";

            _correo.EnvMail(usuario!.Correo, asunto, cuerpoHtml);

            // Retornar la misma vista y pasar un mensaje de éxito
            ViewBag.SuccessMessage = "Se ha enviado un código de verificación a tu correo.";
            return View("Recuperacion");  // Mantener la vista actual
        }



        public IActionResult MenuReco()
        {
            return View("MenuReco");
        }



        // GET: Recovery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recovery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recovery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recovery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recovery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recovery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recovery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recovery/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
