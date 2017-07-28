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
    [Route("api/RegistroPuntoApp")]
    public class RegistroPuntoAppController : Controller
    {
        private readonly checkpointContext _context;

        public RegistroPuntoAppController(checkpointContext context)
        {
            _context = context;
        }

        // GET: api/RegistroPuntoApp
        [HttpGet]
        public IEnumerable<RegistroPunto> GetRegistroPunto()
        {
            return _context.RegistroPunto;
        }

        // GET: api/RegistroPuntoApp/5
        [HttpGet("{id}")]
        public IEnumerable<RegistroPunto> GetRegistroPunto([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var registroPunto = _context.RegistroPunto.Where(m => m.IdPunto == id);

            //if (registroPunto == null)
            //{
            //    return NotFound();
            //}

            return registroPunto;
        }

        // PUT: api/RegistroPuntoApp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroPunto([FromRoute] int id, [FromBody] RegistroPunto registroPunto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroPunto.Id)
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

        // POST: api/RegistroPuntoApp
        [HttpPost]
        public async Task<IActionResult> PostRegistroPunto([FromBody] RegistroPunto registroPunto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegistroPunto.Add(registroPunto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroPunto", new { id = registroPunto.Id }, registroPunto);
        }

        // DELETE: api/RegistroPuntoApp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroPunto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroPunto = await _context.RegistroPunto.SingleOrDefaultAsync(m => m.Id == id);
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
            return _context.RegistroPunto.Any(e => e.Id == id);
        }
    }
}