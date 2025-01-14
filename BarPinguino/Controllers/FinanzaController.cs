using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FinanzaController : Controller
    {
        [Authorize]
        public IActionResult Descuentos()
        {
            return View();
        }
        [Authorize]
        public IActionResult Insumos()
        {
            return View();
        }
        [Authorize]
        public IActionResult Proveedores()
        {
            return View();
        }
        [Authorize]
        public IActionResult Stock()
        {
            return View();
        }
        [Authorize]
        public IActionResult VentasDia()
        {
            return View();
        }
        [Authorize]
        public IActionResult VentasMes()
        {
            return View();
        }
    }
}
