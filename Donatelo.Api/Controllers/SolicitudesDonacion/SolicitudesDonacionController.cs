using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.SolicitudesDonacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesDonacionController : ControllerBase
    {
        private readonly AppdbContext _context;

        public SolicitudesDonacionController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/SolicitudesDonacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudesDonacionDto>>> GetsolicitudesDonacionDtos()
        {
            return await _context.solicitudesDonacionDtos.ToListAsync();
        }

        // GET: api/SolicitudesDonacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudesDonacionDto>> GetSolicitudesDonacionDto(int id)
        {
            var solicitudesDonacionDto = await _context.solicitudesDonacionDtos.FindAsync(id);

            if (solicitudesDonacionDto == null)
            {
                return NotFound();
            }

            return solicitudesDonacionDto;
        }

        // PUT: api/SolicitudesDonacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudesDonacionDto(int id, SolicitudesDonacionDto solicitudesDonacionDto)
        {
            if (id != solicitudesDonacionDto.solicitudId)
            {
                return BadRequest();
            }

            _context.Entry(solicitudesDonacionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesDonacionDtoExists(id))
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

        // POST: api/SolicitudesDonacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SolicitudesDonacionDto>> PostSolicitudesDonacionDto(SolicitudesDonacionDto solicitudesDonacionDto)
        {
            _context.solicitudesDonacionDtos.Add(solicitudesDonacionDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolicitudesDonacionDtoExists(solicitudesDonacionDto.solicitudId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSolicitudesDonacionDto", new { id = solicitudesDonacionDto.solicitudId }, solicitudesDonacionDto);
        }

        // DELETE: api/SolicitudesDonacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitudesDonacionDto(int id)
        {
            var solicitudesDonacionDto = await _context.solicitudesDonacionDtos.FindAsync(id);
            if (solicitudesDonacionDto == null)
            {
                return NotFound();
            }

            _context.solicitudesDonacionDtos.Remove(solicitudesDonacionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudesDonacionDtoExists(int id)
        {
            return _context.solicitudesDonacionDtos.Any(e => e.solicitudId == id);
        }
    }
}
