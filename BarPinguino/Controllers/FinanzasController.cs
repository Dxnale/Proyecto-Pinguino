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

namespace EVA2TI_BarPinguino.Controllers
{
    public class FinanzasController : Controller
    {
        private readonly AppDataContext _context;

        public FinanzasController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Finanzas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Finanzas.ToListAsync());
        }

        // GET: Finanzas/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanzas = await _context.Finanzas
                .FirstOrDefaultAsync(m => m.InformeDeStock == id);
            if (finanzas == null)
            {
                return NotFound();
            }

            return View(finanzas);
        }

        // GET: Finanzas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finanzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("InformeDeStock,Fecha,Gasto,Ingreso,Detalles,NDocumento,TipoDeDocumento")] Finanzas finanzas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finanzas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finanzas);
        }

        // GET: Finanzas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanzas = await _context.Finanzas.FindAsync(id);
            if (finanzas == null)
            {
                return NotFound();
            }
            return View(finanzas);
        }

        // POST: Finanzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("InformeDeStock,Fecha,Gasto,Ingreso,Detalles,NDocumento,TipoDeDocumento")] Finanzas finanzas)
        {
            if (id != finanzas.InformeDeStock)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finanzas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanzasExists(finanzas.InformeDeStock))
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
            return View(finanzas);
        }

        // GET: Finanzas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanzas = await _context.Finanzas
                .FirstOrDefaultAsync(m => m.InformeDeStock == id);
            if (finanzas == null)
            {
                return NotFound();
            }

            return View(finanzas);
        }

        // POST: Finanzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var finanzas = await _context.Finanzas.FindAsync(id);
            if (finanzas != null)
            {
                _context.Finanzas.Remove(finanzas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        private bool FinanzasExists(string id)
        {
            return _context.Finanzas.Any(e => e.InformeDeStock == id);
        }
    }
}
