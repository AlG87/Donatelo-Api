using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.Notificaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public NotificacionesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacionesDto>>> GetnotificacionesDtos()
        {
            return await _context.notificacionesDtos.ToListAsync();
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacionesDto>> GetNotificacionesDto(int id)
        {
            var notificacionesDto = await _context.notificacionesDtos.FindAsync(id);

            if (notificacionesDto == null)
            {
                return NotFound();
            }

            return notificacionesDto;
        }

        // PUT: api/Notificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacionesDto(int id, NotificacionesDto notificacionesDto)
        {
            if (id != notificacionesDto.Notificacionid)
            {
                return BadRequest();
            }

            _context.Entry(notificacionesDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionesDtoExists(id))
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

        // POST: api/Notificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotificacionesDto>> PostNotificacionesDto(NotificacionesDto notificacionesDto)
        {
            _context.notificacionesDtos.Add(notificacionesDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NotificacionesDtoExists(notificacionesDto.Notificacionid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNotificacionesDto", new { id = notificacionesDto.Notificacionid }, notificacionesDto);
        }

        // DELETE: api/Notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacionesDto(int id)
        {
            var notificacionesDto = await _context.notificacionesDtos.FindAsync(id);
            if (notificacionesDto == null)
            {
                return NotFound();
            }

            _context.notificacionesDtos.Remove(notificacionesDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacionesDtoExists(int id)
        {
            return _context.notificacionesDtos.Any(e => e.Notificacionid == id);
        }
    }
}
