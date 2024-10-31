using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.EstadoDonacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoDonacionController : ControllerBase
    {
        private readonly AppdbContext _context;

        public EstadoDonacionController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoDonacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDonacionDto>>> GetestadoDonacionDtos()
        {
            return await _context.estadoDonacionDtos.ToListAsync();
        }

        // GET: api/EstadoDonacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDonacionDto>> GetEstadoDonacionDto(int id)
        {
            var estadoDonacionDto = await _context.estadoDonacionDtos.FindAsync(id);

            if (estadoDonacionDto == null)
            {
                return NotFound();
            }

            return estadoDonacionDto;
        }

        // PUT: api/EstadoDonacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoDonacionDto(int id, EstadoDonacionDto estadoDonacionDto)
        {
            if (id != estadoDonacionDto.estadoid)
            {
                return BadRequest();
            }

            _context.Entry(estadoDonacionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoDonacionDtoExists(id))
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

        // POST: api/EstadoDonacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoDonacionDto>> PostEstadoDonacionDto(EstadoDonacionDto estadoDonacionDto)
        {
            _context.estadoDonacionDtos.Add(estadoDonacionDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoDonacionDtoExists(estadoDonacionDto.estadoid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstadoDonacionDto", new { id = estadoDonacionDto.estadoid }, estadoDonacionDto);
        }

        // DELETE: api/EstadoDonacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoDonacionDto(int id)
        {
            var estadoDonacionDto = await _context.estadoDonacionDtos.FindAsync(id);
            if (estadoDonacionDto == null)
            {
                return NotFound();
            }

            _context.estadoDonacionDtos.Remove(estadoDonacionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoDonacionDtoExists(int id)
        {
            return _context.estadoDonacionDtos.Any(e => e.estadoid == id);
        }
    }
}
