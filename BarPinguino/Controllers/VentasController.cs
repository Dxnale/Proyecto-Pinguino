using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class VentasController : Controller
    {
        [HttpGet]
        public IActionResult RegistrarUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrado(string rut, string nombre, string apellido, string frecuencia) 
        {
            ViewBag.rut = rut;
            ViewBag.nombre = nombre;
            ViewBag.apellido = apellido;
            ViewBag.frecuencia = frecuencia;
            return View();
        }
        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Consulta(string txtRut)
        {
            if (string.IsNullOrWhiteSpace(txtRut))
            {
                ViewBag.ErrorMessage = "El RUT es obligatorio.";
                return View("Consulta");
            }

            ViewBag.ShowModal = true;
            ViewBag.Rut = txtRut;

            return View("Consulta");
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
            return View("/Views/Ventas/Venta.cshtml");
        }
        public IActionResult Boleta()
        {
            return View();
        }
    }
}
