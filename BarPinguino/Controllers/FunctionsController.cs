using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        [HttpGet]
        public IActionResult Venta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Venta(string txtproducto, int txtcantidad, double txtprecio)
        {

            ViewBag.producto = txtproducto;
            ViewBag.cantidad = txtcantidad;
            ViewBag.precio = txtprecio;
            return View("/Views/Functions/Venta.cshtml");
        }
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
    }
}
