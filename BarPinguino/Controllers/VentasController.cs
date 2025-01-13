using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;


namespace EVA2TI_BarPinguino.Controllers
{
    public class VentasController : Controller
    {
        private readonly AppDataContext _context;

        public VentasController(AppDataContext context)
        {
            _context = context;
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
