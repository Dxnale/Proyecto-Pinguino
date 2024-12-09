using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult RegistrarUser()
        {
            return View();
        }
        public IActionResult Registrado(string rut, string nombre, string apellido, string frecuencia, string descuento) 
        {
            ViewBag.rut = rut;
            ViewBag.nombre = nombre;
            ViewBag.apellido = apellido;
            ViewBag.frecuencia = frecuencia;
            ViewBag.descuento = descuento;
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
