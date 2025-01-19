using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class ReporteController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Descuentos()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Insumos()
        {
            return View();
        }
        [Authorize(Roles  ="Admin")]
        public IActionResult Proveedores()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Stock()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult VentasDia()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult VentasMes()
        {
            return View();
        }
    }
}
