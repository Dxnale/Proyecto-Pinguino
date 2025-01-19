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
    public class VentasController : Controller
    {
        private readonly AppDataContext _context;

        public VentasController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Ventas1
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var appDataContext = _context.Ventas.Include(v => v.Cliente).Include(v => v.Usuario);
            return View(await appDataContext.ToListAsync());
        }

        // GET: Ventas1/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.NumBoleta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas1/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ClienteRut"] = new SelectList(_context.Clientes, "Rut", "Rut");
            ViewData["CredencialVendedor"] = new SelectList(_context.Usuarios, "CredencialVendedor", "Clave");
            return View();
        }

        // POST: Ventas1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("NumBoleta,CredencialVendedor,Detalles,ClienteRut,TotalDelPedido")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteRut"] = new SelectList(_context.Clientes, "Rut", "Rut", venta.ClienteRut);
            ViewData["CredencialVendedor"] = new SelectList(_context.Usuarios, "CredencialVendedor", "Clave", venta.CredencialVendedor);
            return View(venta);
        }

        // GET: Ventas1/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteRut"] = new SelectList(_context.Clientes, "Rut", "Rut", venta.ClienteRut);
            ViewData["CredencialVendedor"] = new SelectList(_context.Usuarios, "CredencialVendedor", "Clave", venta.CredencialVendedor);
            return View(venta);
        }

        // POST: Ventas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("NumBoleta,CredencialVendedor,Detalles,ClienteRut,TotalDelPedido")] Venta venta)
        {
            if (id != venta.NumBoleta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.NumBoleta))
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
            ViewData["ClienteRut"] = new SelectList(_context.Clientes, "Rut", "Rut", venta.ClienteRut);
            ViewData["CredencialVendedor"] = new SelectList(_context.Usuarios, "CredencialVendedor", "Clave", venta.CredencialVendedor);
            return View(venta);
        }

        // GET: Ventas1/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.NumBoleta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(string id)
        {
            return _context.Ventas.Any(e => e.NumBoleta == id);
        }
    }
}
