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
    public class PuntoControlController : Controller
    {
        private readonly CHECKPOINTContext _context;

        public PuntoControlController(CHECKPOINTContext context)
        {
            _context = context;    
        }

        // GET: PuntoControl
        public async Task<IActionResult> Index()
        {
            var cHECKPOINTContext = _context.PuntoControl.Include(p => p.IdUbicacionNavigation);
            return View(await cHECKPOINTContext.ToListAsync());
        }

        // GET: PuntoControl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoControl = await _context.PuntoControl
                .Include(p => p.IdUbicacionNavigation)
                .SingleOrDefaultAsync(m => m.IdPuntoControl == id);
            if (puntoControl == null)
            {
                return NotFound();
            }

            return View(puntoControl);
        }

        // GET: PuntoControl/Create
        public IActionResult Create()
        {
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicacion, "IdUbicacion", "IdUbicacion");
            return View();
        }

        // POST: PuntoControl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuntoControl,DescripcionDispositivo,IdUbicacion")] PuntoControl puntoControl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puntoControl);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicacion, "IdUbicacion", "IdUbicacion", puntoControl.IdUbicacion);
            return View(puntoControl);
        }

        // GET: PuntoControl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoControl = await _context.PuntoControl.SingleOrDefaultAsync(m => m.IdPuntoControl == id);
            if (puntoControl == null)
            {
                return NotFound();
            }
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicacion, "IdUbicacion", "IdUbicacion", puntoControl.IdUbicacion);
            return View(puntoControl);
        }

        // POST: PuntoControl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuntoControl,DescripcionDispositivo,IdUbicacion")] PuntoControl puntoControl)
        {
            if (id != puntoControl.IdPuntoControl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puntoControl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntoControlExists(puntoControl.IdPuntoControl))
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
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicacion, "IdUbicacion", "IdUbicacion", puntoControl.IdUbicacion);
            return View(puntoControl);
        }

        // GET: PuntoControl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoControl = await _context.PuntoControl
                .Include(p => p.IdUbicacionNavigation)
                .SingleOrDefaultAsync(m => m.IdPuntoControl == id);
            if (puntoControl == null)
            {
                return NotFound();
            }

            return View(puntoControl);
        }

        // POST: PuntoControl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puntoControl = await _context.PuntoControl.SingleOrDefaultAsync(m => m.IdPuntoControl == id);
            _context.PuntoControl.Remove(puntoControl);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PuntoControlExists(int id)
        {
            return _context.PuntoControl.Any(e => e.IdPuntoControl == id);
        }
    }
}
