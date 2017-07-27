using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManejadorCheckpoint.Models;

namespace ManejadorCheckpoint.Controllers
{
    public class TipoVehiculoController : Controller
    {
        private readonly CHECKPOINTContext _context;

        public TipoVehiculoController(CHECKPOINTContext context)
        {
            _context = context;    
        }

        // GET: TipoVehiculo
        public async Task<IActionResult> Index()
        {
            var cHECKPOINTContext = _context.TipoVehiculo.Include(t => t.IdRutaNavigation);
            return View(await cHECKPOINTContext.ToListAsync());
        }

        // GET: TipoVehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVehiculo = await _context.TipoVehiculo
                .Include(t => t.IdRutaNavigation)
                .SingleOrDefaultAsync(m => m.IdTipoVehiculo == id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return View(tipoVehiculo);
        }

        // GET: TipoVehiculo/Create
        public IActionResult Create()
        {
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta");
            return View();
        }

        // POST: TipoVehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoVehiculo,Etiqueta,IdRuta")] TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", tipoVehiculo.IdRuta);
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVehiculo = await _context.TipoVehiculo.SingleOrDefaultAsync(m => m.IdTipoVehiculo == id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", tipoVehiculo.IdRuta);
            return View(tipoVehiculo);
        }

        // POST: TipoVehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoVehiculo,Etiqueta,IdRuta")] TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.IdTipoVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoVehiculoExists(tipoVehiculo.IdTipoVehiculo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", tipoVehiculo.IdRuta);
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVehiculo = await _context.TipoVehiculo
                .Include(t => t.IdRutaNavigation)
                .SingleOrDefaultAsync(m => m.IdTipoVehiculo == id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return View(tipoVehiculo);
        }

        // POST: TipoVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoVehiculo = await _context.TipoVehiculo.SingleOrDefaultAsync(m => m.IdTipoVehiculo == id);
            _context.TipoVehiculo.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TipoVehiculoExists(int id)
        {
            return _context.TipoVehiculo.Any(e => e.IdTipoVehiculo == id);
        }
    }
}
