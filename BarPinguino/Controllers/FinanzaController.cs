using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FinanzaController : Controller
    {
        public IActionResult Decuentos()
        {
            return View();
        }
        public IActionResult Insumos()
        {
            return View();
        }
        public IActionResult Proveedores()
        {
            return View();
        }
        public IActionResult Stock()
        {
            return View();
        }
        public IActionResult VentasDia()
        {
            return View();
        }
        public IActionResult VentasMes()
        {
            return View();
        }
    }
}
