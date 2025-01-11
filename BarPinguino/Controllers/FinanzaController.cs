using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FinanzaController : Controller
    {
        private IActionResult ViewIfIsAdmin()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                return View();
            
            return RedirectToAction("Login", "Taller");
        }

        public IActionResult Descuentos()
        {
            return ViewIfIsAdmin();
        }
        public IActionResult Insumos()
        {
            return ViewIfIsAdmin();
        }
        public IActionResult Proveedores()
        {
            return ViewIfIsAdmin();
        }
        public IActionResult Stock()
        {
            return ViewIfIsAdmin();
        }
        public IActionResult VentasDia()
        {
            return ViewIfIsAdmin();
        }
        public IActionResult VentasMes()
        {
            return ViewIfIsAdmin();
        }
    }
}
