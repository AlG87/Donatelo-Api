using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonateloApiRest.Models;

namespace DonateloApiRest.Controllers.EstadoDonaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoDonacionsController : ControllerBase
    {
        private readonly DonateloDbOficialContext _context;

        public EstadoDonacionsController(DonateloDbOficialContext context)
        {
            _context = context;
        }

        // GET: api/EstadoDonacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDonacion>>> GetEstadoDonacions()
        {
            return await _context.EstadoDonacions.ToListAsync();
        }

        // GET: api/EstadoDonacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDonacion>> GetEstadoDonacion(int id)
        {
            var estadoDonacion = await _context.EstadoDonacions.FindAsync(id);

            if (estadoDonacion == null)
            {
                return NotFound();
            }

            return estadoDonacion;
        }

        // PUT: api/EstadoDonacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoDonacion(int id, EstadoDonacion estadoDonacion)
        {
            if (id != estadoDonacion.EstadoId)
            {
                return BadRequest();
            }

            _context.Entry(estadoDonacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoDonacionExists(id))
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

        // POST: api/EstadoDonacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoDonacion>> PostEstadoDonacion(EstadoDonacion estadoDonacion)
        {
            _context.EstadoDonacions.Add(estadoDonacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoDonacion", new { id = estadoDonacion.EstadoId }, estadoDonacion);
        }

        // DELETE: api/EstadoDonacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoDonacion(int id)
        {
            var estadoDonacion = await _context.EstadoDonacions.FindAsync(id);
            if (estadoDonacion == null)
            {
                return NotFound();
            }

            _context.EstadoDonacions.Remove(estadoDonacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoDonacionExists(int id)
        {
            return _context.EstadoDonacions.Any(e => e.EstadoId == id);
        }
    }
}
