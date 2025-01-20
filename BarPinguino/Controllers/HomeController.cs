using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EVA2TI_BarPinguino.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Index()
        {
            var tipoDeUsuario = User.Claims.FirstOrDefault(c => c.Type == "TipoDeUsuario")?.Value;
            return View("/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("Error404");
        }
    }
}
