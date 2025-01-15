using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Preparacion()
        {
            return View("/Views/Functions/Preparacion.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Procedimiento()
        {
            return View("/Views/Functions/Procedimiento.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Inventario()
        {
            return View("/Views/Functions/Inventario.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Restock()
        {
            return View("/Views/Functions/Restock.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult CorreoProveedores()
        {
            return View("/Views/Functions/CorreoProveedores.cshtml");
        }
    }
}