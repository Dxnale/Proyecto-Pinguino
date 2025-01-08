using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using Humanizer;

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
        public IActionResult RegistrarUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrado(Clientes clientes)
        {
            
                var newuser = new Clientes
                {
                    Rut = clientes.Rut,
                    Nombre = clientes.Nombre,
                    Apellido = clientes.Apellido,
                    Frecuente = clientes.Frecuente
                };
                _context.Clientes.Add(newuser);
                _context.SaveChanges();
            

            return View("Registrado", clientes);
        }
        
        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Consulta(string txtRut)
        {
            var cl = _context.Clientes.FirstOrDefault(c => c.Rut == txtRut);
            if (cl != null)
            { 
                ViewBag.ShowModal = true;
                return View(cl);
            }
            
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
            return View("/Views/Ventas/Venta.cshtml");
        }
        public IActionResult Boleta()
        {
            return View();
        }
    }
}
