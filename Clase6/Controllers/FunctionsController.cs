using Microsoft.AspNetCore.Mvc;

namespace Clase6.Controllers
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
    }
}
