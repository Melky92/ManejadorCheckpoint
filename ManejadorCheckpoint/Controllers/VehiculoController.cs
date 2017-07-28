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
    public class VehiculoController : Controller
    {
        private readonly checkpointContext _context;

        public VehiculoController(checkpointContext context)
        {
            _context = context;    
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            var checkpointContext = _context.Vehiculo.Include(v => v.IdTipoVehiculoNavigation);
            return View(await checkpointContext.ToListAsync());
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.IdTipoVehiculoNavigation)
                .SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoVehiculo, "IdTipoVehiculo", "Etiqueta");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,Placa,IdentificadorBt,IdTipoVehiculo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoVehiculo, "IdTipoVehiculo", "Etiqueta", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoVehiculo, "IdTipoVehiculo", "Etiqueta", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,Placa,IdentificadorBt,IdTipoVehiculo")] Vehiculo vehiculo)
        {
            if (id != vehiculo.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.IdVehiculo))
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
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoVehiculo, "IdTipoVehiculo", "Etiqueta", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.IdTipoVehiculoNavigation)
                .SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculo.SingleOrDefaultAsync(m => m.IdVehiculo == id);
            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculo.Any(e => e.IdVehiculo == id);
        }
    }
}
