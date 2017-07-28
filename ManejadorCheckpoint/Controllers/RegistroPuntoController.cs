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
    public class RegistroPuntoController : Controller
    {
        private readonly checkpointContext _context;

        public RegistroPuntoController(checkpointContext context)
        {
            _context = context;    
        }

        // GET: RegistroPunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroPunto.ToListAsync());
        }

        // GET: RegistroPunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto
                .SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (registroPunto == null)
            {
                return NotFound();
            }

            return View(registroPunto);
        }

        // GET: RegistroPunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroPunto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,IdPunto,FechaHora,Debug")] RegistroPunto registroPunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroPunto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registroPunto);
        }

        // GET: RegistroPunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (registroPunto == null)
            {
                return NotFound();
            }
            return View(registroPunto);
        }

        // POST: RegistroPunto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,IdPunto,FechaHora,Debug")] RegistroPunto registroPunto)
        {
            if (id != registroPunto.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroPunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroPuntoExists(registroPunto.IdVehiculo))
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
            return View(registroPunto);
        }

        // GET: RegistroPunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto
                .SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (registroPunto == null)
            {
                return NotFound();
            }

            return View(registroPunto);
        }

        // POST: RegistroPunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.IdVehiculo == id);
            _context.RegistroPunto.Remove(registroPunto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegistroPuntoExists(int id)
        {
            return _context.RegistroPunto.Any(e => e.IdVehiculo == id);
        }
    }
}
