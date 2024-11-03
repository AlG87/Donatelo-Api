using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonateloApiRest.Models;

namespace DonateloApiRest.Controllers.EstadoPublicaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPublicacionsController : ControllerBase
    {
        private readonly DonateloDbOficialContext _context;

        public EstadoPublicacionsController(DonateloDbOficialContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPublicacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPublicacion>>> GetEstadoPublicacions()
        {
            return await _context.EstadoPublicacions.ToListAsync();
        }

        // GET: api/EstadoPublicacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPublicacion>> GetEstadoPublicacion(int id)
        {
            var estadoPublicacion = await _context.EstadoPublicacions.FindAsync(id);

            if (estadoPublicacion == null)
            {
                return NotFound();
            }

            return estadoPublicacion;
        }

        // PUT: api/EstadoPublicacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPublicacion(int id, EstadoPublicacion estadoPublicacion)
        {
            if (id != estadoPublicacion.EstadoId)
            {
                return BadRequest();
            }

            _context.Entry(estadoPublicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPublicacionExists(id))
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

        // POST: api/EstadoPublicacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPublicacion>> PostEstadoPublicacion(EstadoPublicacion estadoPublicacion)
        {
            _context.EstadoPublicacions.Add(estadoPublicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPublicacion", new { id = estadoPublicacion.EstadoId }, estadoPublicacion);
        }

        // DELETE: api/EstadoPublicacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPublicacion(int id)
        {
            var estadoPublicacion = await _context.EstadoPublicacions.FindAsync(id);
            if (estadoPublicacion == null)
            {
                return NotFound();
            }

            _context.EstadoPublicacions.Remove(estadoPublicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPublicacionExists(int id)
        {
            return _context.EstadoPublicacions.Any(e => e.EstadoId == id);
        }
    }
}
