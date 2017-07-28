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
    public class RegistroPuntoMvcController : Controller
    {
        private readonly checkpointContext _context;

        public RegistroPuntoMvcController(checkpointContext context)
        {
            _context = context;    
        }

        // GET: RegistroPuntoMvc
        public async Task<IActionResult> Index()
        {
            var checkpointContext = _context.RegistroPunto.Include(r => r.Vehiculo);
            return View(await checkpointContext.ToListAsync());
        }

        // GET: RegistroPuntoMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto
                .Include(r => r.Vehiculo)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (registroPunto == null)
            {
                return NotFound();
            }

            return View(registroPunto);
        }

        // GET: RegistroPuntoMvc/Create
        public IActionResult Create()
        {
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Placa");
            return View();
        }

        // POST: RegistroPuntoMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdVehiculo,IdPunto,FechaHora,Debug")] RegistroPunto registroPunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroPunto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Placa", registroPunto.IdVehiculo);
            return View(registroPunto);
        }

        // GET: RegistroPuntoMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.Id == id);
            if (registroPunto == null)
            {
                return NotFound();
            }
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Placa", registroPunto.IdVehiculo);
            return View(registroPunto);
        }

        // POST: RegistroPuntoMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdVehiculo,IdPunto,FechaHora,Debug")] RegistroPunto registroPunto)
        {
            if (id != registroPunto.Id)
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
                    if (!RegistroPuntoExists(registroPunto.Id))
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
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Placa", registroPunto.IdVehiculo);
            return View(registroPunto);
        }

        // GET: RegistroPuntoMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroPunto = await _context.RegistroPunto
                .Include(r => r.Vehiculo)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (registroPunto == null)
            {
                return NotFound();
            }

            return View(registroPunto);
        }

        // POST: RegistroPuntoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.Id == id);
            _context.RegistroPunto.Remove(registroPunto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegistroPuntoExists(int id)
        {
            return _context.RegistroPunto.Any(e => e.Id == id);
        }
    }
}
