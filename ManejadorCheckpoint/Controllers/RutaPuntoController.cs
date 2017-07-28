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
    public class RutaPuntoController : Controller
    {
        private readonly checkpointContext _context;

        public RutaPuntoController(checkpointContext context)
        {
            _context = context;    
        }

        // GET: RutaPunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.RutaPunto.ToListAsync());
        }

        // GET: RutaPunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutaPunto = await _context.RutaPunto
                .SingleOrDefaultAsync(m => m.IdRuta == id);
            if (rutaPunto == null)
            {
                return NotFound();
            }

            return View(rutaPunto);
        }

        // GET: RutaPunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RutaPunto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRuta,IdPunto,Numero")] RutaPunto rutaPunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutaPunto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rutaPunto);
        }

        // GET: RutaPunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutaPunto = await _context.RutaPunto.SingleOrDefaultAsync(m => m.IdRuta == id);
            if (rutaPunto == null)
            {
                return NotFound();
            }
            return View(rutaPunto);
        }

        // POST: RutaPunto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRuta,IdPunto,Numero")] RutaPunto rutaPunto)
        {
            if (id != rutaPunto.IdRuta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutaPunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutaPuntoExists(rutaPunto.IdRuta))
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
            return View(rutaPunto);
        }

        // GET: RutaPunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutaPunto = await _context.RutaPunto
                .SingleOrDefaultAsync(m => m.IdRuta == id);
            if (rutaPunto == null)
            {
                return NotFound();
            }

            return View(rutaPunto);
        }

        // POST: RutaPunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutaPunto = await _context.RutaPunto.SingleOrDefaultAsync(m => m.IdRuta == id);
            _context.RutaPunto.Remove(rutaPunto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RutaPuntoExists(int id)
        {
            return _context.RutaPunto.Any(e => e.IdRuta == id);
        }
    }
}
