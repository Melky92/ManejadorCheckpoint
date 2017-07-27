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
    public class RutaController : Controller
    {
        private readonly CHECKPOINTContext _context;

        public RutaController(CHECKPOINTContext context)
        {
            _context = context;    
        }

        // GET: Ruta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ruta.ToListAsync());
        }

        // GET: Ruta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta
                .SingleOrDefaultAsync(m => m.IdRuta == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // GET: Ruta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ruta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRuta,CantidadDePuntos")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ruta);
        }

        // GET: Ruta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta.SingleOrDefaultAsync(m => m.IdRuta == id);
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: Ruta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRuta,CantidadDePuntos")] Ruta ruta)
        {
            if (id != ruta.IdRuta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutaExists(ruta.IdRuta))
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
            return View(ruta);
        }

        // GET: Ruta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta
                .SingleOrDefaultAsync(m => m.IdRuta == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // POST: Ruta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ruta = await _context.Ruta.SingleOrDefaultAsync(m => m.IdRuta == id);
            _context.Ruta.Remove(ruta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RutaExists(int id)
        {
            return _context.Ruta.Any(e => e.IdRuta == id);
        }
    }
}
