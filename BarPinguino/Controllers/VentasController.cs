using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace EVA2TI_BarPinguino.Controllers
{
    [Authorize(Roles = "Admin,Ventas")]
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
            var credencial = User.FindFirst("Credencial_Vendedor")!.Value;
            return View("/Views/Ventas/Venta.cshtml");
        }
        public IActionResult Boleta()
        {
            return View();
        }
    }
}
