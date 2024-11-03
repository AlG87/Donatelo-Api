using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonateloApiRest.Models;

namespace DonateloApiRest.Controllers.Publicaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly DonateloDbOficialContext _context;

        public PublicacionesController(DonateloDbOficialContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacione>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }

        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacione>> GetPublicacione(int id)
        {
            var publicacione = await _context.Publicaciones.FindAsync(id);

            if (publicacione == null)
            {
                return NotFound();
            }

            return publicacione;
        }

        // PUT: api/Publicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacione(int id, Publicacione publicacione)
        {
            if (id != publicacione.PublicacionId)
            {
                return BadRequest();
            }

            _context.Entry(publicacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacioneExists(id))
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

        // POST: api/Publicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publicacione>> PostPublicacione(Publicacione publicacione)
        {
            _context.Publicaciones.Add(publicacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacione", new { id = publicacione.PublicacionId }, publicacione);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacione(int id)
        {
            var publicacione = await _context.Publicaciones.FindAsync(id);
            if (publicacione == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacioneExists(int id)
        {
            return _context.Publicaciones.Any(e => e.PublicacionId == id);
        }
    }
}
