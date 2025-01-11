using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FinanzaController : BaseController
    {
        public IActionResult Descuentos()
        {
            return ViewIfIsRole("Admin");
        }
        public IActionResult Insumos()
        {
            return ViewIfIsRole("Admin");
        }
        public IActionResult Proveedores()
        {
            return ViewIfIsRole("Admin");
        }
        public IActionResult Stock()
        {
            return ViewIfIsRole("Admin");
        }
        public IActionResult VentasDia()
        {
            return ViewIfIsRole("Admin");
        }
        public IActionResult VentasMes()
        {
            return ViewIfIsRole("Admin");
        }
    }
}
