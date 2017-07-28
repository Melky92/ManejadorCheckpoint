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
    [Route("api/PuntoControlApi")]
    public class PuntoControlApiController : Controller
    {
        private readonly checkpointContext _context;

        public PuntoControlApiController(checkpointContext context)
        {
            _context = context;
        }

        // GET: api/PuntoControlApi
        [HttpGet]
        public IEnumerable<PuntoControl> GetPuntoControl()
        {
            return _context.PuntoControl;
        }

        // GET: api/PuntoControlApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuntoControl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puntoControl = await _context.PuntoControl.SingleOrDefaultAsync(m => m.IdPuntoControl == id);

            if (puntoControl == null)
            {
                return NotFound();
            }

            return Ok(puntoControl);
        }

        // PUT: api/PuntoControlApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntoControl([FromRoute] int id, [FromBody] PuntoControl puntoControl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puntoControl.IdPuntoControl)
            {
                return BadRequest();
            }

            _context.Entry(puntoControl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntoControlExists(id))
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

        // POST: api/PuntoControlApi
        [HttpPost]
        public async Task<IActionResult> PostPuntoControl([FromBody] PuntoControl puntoControl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PuntoControl.Add(puntoControl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuntoControl", new { id = puntoControl.IdPuntoControl }, puntoControl);
        }

        // DELETE: api/PuntoControlApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntoControl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puntoControl = await _context.PuntoControl.SingleOrDefaultAsync(m => m.IdPuntoControl == id);
            if (puntoControl == null)
            {
                return NotFound();
            }

            _context.PuntoControl.Remove(puntoControl);
            await _context.SaveChangesAsync();

            return Ok(puntoControl);
        }

        private bool PuntoControlExists(int id)
        {
            return _context.PuntoControl.Any(e => e.IdPuntoControl == id);
        }
    }
}