using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        public IActionResult Preparacion()
        {
            return View("/Views/Functions/Preparacion.cshtml");
        }
        public IActionResult Procedimiento()
        {
            return View("/Views/Functions/Procedimiento.cshtml");
        }
        public IActionResult Inventario()
        {
            return View("/Views/Functions/Inventario.cshtml");
        }
        public IActionResult Restock()
        {
            return View("/Views/Functions/Restock.cshtml");
        }
        public IActionResult CorreoProveedores()
        {
            return View("/Views/Functions/CorreoProveedores.cshtml");
        }
    }
}