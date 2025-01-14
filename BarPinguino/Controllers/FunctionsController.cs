using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        [Authorize]
        public IActionResult Preparacion()
        {
            return View("/Views/Functions/Preparacion.cshtml");
        }
        [Authorize]
        public IActionResult Procedimiento()
        {
            return View("/Views/Functions/Procedimiento.cshtml");
        }
        [Authorize]
        public IActionResult Inventario()
        {
            return View("/Views/Functions/Inventario.cshtml");
        }
        [Authorize]
        public IActionResult Restock()
        {
            return View("/Views/Functions/Restock.cshtml");
        }
        [Authorize]
        public IActionResult CorreoProveedores()
        {
            return View("/Views/Functions/CorreoProveedores.cshtml");
        }
    }
}