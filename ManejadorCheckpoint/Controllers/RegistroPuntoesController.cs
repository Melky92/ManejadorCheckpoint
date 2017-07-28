using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManejadorCheckpoint.Models;

namespace ManejadorCheckpoint.Controllers
{
    [Produces("application/json")]
    [Route("api/RegistroPuntoes")]
    public class RegistroPuntoesController : Controller
    {
        private readonly checkpointContext _context;

        public RegistroPuntoesController(checkpointContext context)
        {
            _context = context;
        }

        // GET: api/RegistroPuntoes
        [HttpGet]
        public IEnumerable<RegistroPunto> GetRegistroPunto()
        {
            return _context.RegistroPunto;
        }

        // GET: api/RegistroPuntoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistroPunto([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            RegistroPunto registroPunto = new RegistroPunto();
            registroPunto.IdPunto = 1;//System.Convert.ToInt32(dato.Split('@')[0]);
            registroPunto.IdVehiculo = id;//_context.Vehiculo.ToList().FirstOrDefault(v => v.IdentificadorBt == dato.Split('@')[1]).IdVehiculo;
            registroPunto.FechaHora = DateTime.UtcNow.AddHours(-4);
            //registroPunto.Debug = dato;

            _context.RegistroPunto.Add(registroPunto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistroPuntoExists(registroPunto.IdVehiculo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Ok(registroPunto);

            //var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.IdVehiculo == id);

            //if (registroPunto == null)
            //{
            //    return NotFound();
            //}

            //return Ok(registroPunto);
        }

        // PUT: api/RegistroPuntoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroPunto([FromRoute] int id, [FromBody] RegistroPunto registroPunto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroPunto.IdVehiculo)
            {
                return BadRequest();
            }

            _context.Entry(registroPunto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroPuntoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RegistroPuntoes
        [HttpPost]
        public async Task<IActionResult> PostRegistroPunto([FromBody] RegistroPunto registroPunto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegistroPunto.Add(registroPunto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistroPuntoExists(registroPunto.IdVehiculo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistroPunto", new { id = registroPunto.IdVehiculo }, registroPunto);
        }

        // DELETE: api/RegistroPuntoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroPunto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.IdVehiculo == id);
            if (registroPunto == null)
            {
                return NotFound();
            }

            _context.RegistroPunto.Remove(registroPunto);
            await _context.SaveChangesAsync();

            return Ok(registroPunto);
        }

        private bool RegistroPuntoExists(int id)
        {
            return _context.RegistroPunto.Any(e => e.IdVehiculo == id);
        }
    }
}