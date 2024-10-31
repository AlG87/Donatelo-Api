using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.EstadoPublicacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPublicacionController : ControllerBase
    {
        private readonly AppdbContext _context;

        public EstadoPublicacionController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPublicacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPublicacionDto>>> GetestadoPublicacionDtos()
        {
            return await _context.estadoPublicacionDtos.ToListAsync();
        }

        // GET: api/EstadoPublicacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPublicacionDto>> GetEstadoPublicacionDto(int id)
        {
            var estadoPublicacionDto = await _context.estadoPublicacionDtos.FindAsync(id);

            if (estadoPublicacionDto == null)
            {
                return NotFound();
            }

            return estadoPublicacionDto;
        }

        // PUT: api/EstadoPublicacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPublicacionDto(int id, EstadoPublicacionDto estadoPublicacionDto)
        {
            if (id != estadoPublicacionDto.estadoid)
            {
                return BadRequest();
            }

            _context.Entry(estadoPublicacionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPublicacionDtoExists(id))
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

        // POST: api/EstadoPublicacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPublicacionDto>> PostEstadoPublicacionDto(EstadoPublicacionDto estadoPublicacionDto)
        {
            _context.estadoPublicacionDtos.Add(estadoPublicacionDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoPublicacionDtoExists(estadoPublicacionDto.estadoid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstadoPublicacionDto", new { id = estadoPublicacionDto.estadoid }, estadoPublicacionDto);
        }

        // DELETE: api/EstadoPublicacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPublicacionDto(int id)
        {
            var estadoPublicacionDto = await _context.estadoPublicacionDtos.FindAsync(id);
            if (estadoPublicacionDto == null)
            {
                return NotFound();
            }

            _context.estadoPublicacionDtos.Remove(estadoPublicacionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPublicacionDtoExists(int id)
        {
            return _context.estadoPublicacionDtos.Any(e => e.estadoid == id);
        }
    }
}
