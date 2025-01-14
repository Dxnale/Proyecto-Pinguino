using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace EVA2TI_BarPinguino.Controllers
{
    public class VentasController : Controller
    {
        private readonly AppDataContext _context;

        public VentasController(AppDataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Venta()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Venta(string txtproducto, int txtcantidad, double txtprecio)
        {
            var credencial = User.FindFirst("Credencial_Vendedor")!.Value;
            return View("/Views/Ventas/Venta.cshtml");
        }
        [Authorize]
        public IActionResult Boleta()
        {
            return View();
        }
    }
}
