using EVA2TI_BarPinguino.Data;
using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVA2TI_BarPinguino.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ReporteController : Controller
    {
        private readonly AppDataContext _context;
        public ReporteController(AppDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Descuentos(string search)
        {
            var query = _context.Descuentos.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                if (int.TryParse(search, out int sku))
                {
                    query = query.Where(p => p.SKU == sku);
                }
            }

            var productosConDescuento = await query.ToListAsync();

            return View(productosConDescuento);
        }

        public async Task<IActionResult> Proveedores(string search)
        {
            var query = _context.Proveedores.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p =>
                    p.RazonSocial.Contains(search) ||
                    p.DatosBanco.Contains(search) ||
                    p.Giro.Contains(search));
            }

            var proveedores = await query.ToListAsync();

            return View(proveedores);
        }

        public async Task<IActionResult> Stock(string search)
        {
            var query = _context.Stocks.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NombreProducto.Contains(search));
            }

            var productos = await query.ToListAsync();

            return View(productos);
        }

        public async Task<IActionResult> VentasDia(string search, DateTime? date)
        {
            var query = _context.Ventas.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(v => v.ClienteRut.Contains(search) || v.Detalles.Contains(search));
            }

            if (date.HasValue)
            {
                var selectedDate = DateOnly.FromDateTime(date.Value);
                query = query.Where(v => v.Fecha == selectedDate);
            }

            var ventas = await query.ToListAsync();

            return View(ventas);
        }

        public async Task<IActionResult> VentasMes(string search, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Ventas.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(v => v.ClienteRut.Contains(search) || v.Detalles.Contains(search));
            }

            if (startDate.HasValue)
            {
                var start = DateOnly.FromDateTime(startDate.Value);
                query = query.Where(v => v.Fecha >= start);
            }

            if (endDate.HasValue)
            {
                var end = DateOnly.FromDateTime(endDate.Value);
                query = query.Where(v => v.Fecha <= end);
            }

            var ventas = await query.ToListAsync();

            return View(ventas);
        }

    }
}
