using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonateloApiRest.Models;

namespace DonateloApiRest.Controllers.SolicitudesDonaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesDonacionsController : ControllerBase
    {
        private readonly DonateloDbOficialContext _context;

        public SolicitudesDonacionsController(DonateloDbOficialContext context)
        {
            _context = context;
        }

        // GET: api/SolicitudesDonacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudesDonacion>>> GetSolicitudesDonacions()
        {
            return await _context.SolicitudesDonacions.ToListAsync();
        }

        // GET: api/SolicitudesDonacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudesDonacion>> GetSolicitudesDonacion(int id)
        {
            var solicitudesDonacion = await _context.SolicitudesDonacions.FindAsync(id);

            if (solicitudesDonacion == null)
            {
                return NotFound();
            }

            return solicitudesDonacion;
        }

        // PUT: api/SolicitudesDonacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudesDonacion(int id, SolicitudesDonacion solicitudesDonacion)
        {
            if (id != solicitudesDonacion.SolicitudId)
            {
                return BadRequest();
            }

            _context.Entry(solicitudesDonacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesDonacionExists(id))
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

        // POST: api/SolicitudesDonacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SolicitudesDonacion>> PostSolicitudesDonacion(SolicitudesDonacion solicitudesDonacion)
        {
            _context.SolicitudesDonacions.Add(solicitudesDonacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitudesDonacion", new { id = solicitudesDonacion.SolicitudId }, solicitudesDonacion);
        }

        // DELETE: api/SolicitudesDonacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitudesDonacion(int id)
        {
            var solicitudesDonacion = await _context.SolicitudesDonacions.FindAsync(id);
            if (solicitudesDonacion == null)
            {
                return NotFound();
            }

            _context.SolicitudesDonacions.Remove(solicitudesDonacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudesDonacionExists(int id)
        {
            return _context.SolicitudesDonacions.Any(e => e.SolicitudId == id);
        }
    }
}
