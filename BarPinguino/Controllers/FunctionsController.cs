using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        public IActionResult RegistrarUser() {
            return View();
        }
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
    }
}
