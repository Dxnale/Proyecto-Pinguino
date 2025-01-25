using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVA2TI_BarPinguino.Data;
using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Authorization;

namespace EVA2TI_BarPinguino.Controllers.Maestro
{
    public class DescuentosController : Controller
    {
        private readonly AppDataContext _context;

        public DescuentosController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Descuentos
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Index()
        {
            var appDataContext = _context.Descuentos.Include(d => d.Stock);
            return View(await appDataContext.ToListAsync());
        }

        // GET: Descuentos/Details/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos
                .Include(d => d.Stock)
                .FirstOrDefaultAsync(m => m.SKU == id);
            if (descuentos == null)
            {
                return NotFound();
            }

            return View(descuentos);
        }

        // GET: Descuentos/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            ViewData["SKU"] = new SelectList(_context.Stocks, "SKU", "NombreProducto");
            return View();
        }

        // POST: Descuentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("SKU,PrecioOriginal,PrecioConDescuento")] Descuentos descuentos)
        {
            
                _context.Add(descuentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Descuentos/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos.FindAsync(id);
            if (descuentos == null)
            {
                return NotFound();
            }
            ViewData["SKU"] = new SelectList(_context.Stocks, "SKU", "NombreProducto", descuentos.SKU);
            return View(descuentos);
        }

        // POST: Descuentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("SKU,PrecioOriginal,PrecioConDescuento")] Descuentos descuentos)
        {
            if (id != descuentos.SKU)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(descuentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescuentosExists(descuentos.SKU))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: Descuentos/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos
                .Include(d => d.Stock)
                .FirstOrDefaultAsync(m => m.SKU == id);
            if (descuentos == null)
            {
                return NotFound();
            }

            return View(descuentos);
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descuentos = await _context.Descuentos.FindAsync(id);
            if (descuentos != null)
            {
                _context.Descuentos.Remove(descuentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        private bool DescuentosExists(int id)
        {
            return _context.Descuentos.Any(e => e.SKU == id);
        }
    }
}
