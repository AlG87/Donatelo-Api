using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.Publicaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public PublicacionesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionDto>>> GetPublicacionDtos()
        {
            return await _context.PublicacionDtos.ToListAsync();
        }

        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicacionDto>> GetPublicacionDto(int id)
        {
            var publicacionDto = await _context.PublicacionDtos.FindAsync(id);

            if (publicacionDto == null)
            {
                return NotFound();
            }

            return publicacionDto;
        }

        // PUT: api/Publicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacionDto(int id, PublicacionDto publicacionDto)
        {
            if (id != publicacionDto.PublicacionId)
            {
                return BadRequest();
            }

            _context.Entry(publicacionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionDtoExists(id))
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
        public async Task<ActionResult<PublicacionDto>> PostPublicacionDto(PublicacionDto publicacionDto)
        {
            _context.PublicacionDtos.Add(publicacionDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublicacionDtoExists(publicacionDto.PublicacionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublicacionDto", new { id = publicacionDto.PublicacionId }, publicacionDto);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacionDto(int id)
        {
            var publicacionDto = await _context.PublicacionDtos.FindAsync(id);
            if (publicacionDto == null)
            {
                return NotFound();
            }

            _context.PublicacionDtos.Remove(publicacionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacionDtoExists(int id)
        {
            return _context.PublicacionDtos.Any(e => e.PublicacionId == id);
        }
    }
}
