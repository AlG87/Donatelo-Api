using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.Sedes
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public SedesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SedeDto>>> GetSedeDTO()
        {
            return await _context.SedeDTO.ToListAsync();
        }

        // GET: api/Sedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SedeDto>> GetSedeDto(int id)
        {
            var sedeDto = await _context.SedeDTO.FindAsync(id);

            if (sedeDto == null)
            {
                return NotFound();
            }

            return sedeDto;
        }

        // PUT: api/Sedes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSedeDto(int id, SedeDto sedeDto)
        {
            if (id != sedeDto.SedeId)
            {
                return BadRequest();
            }

            _context.Entry(sedeDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeDtoExists(id))
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

        // POST: api/Sedes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SedeDto>> PostSedeDto(SedeDto sedeDto)
        {
            _context.SedeDTO.Add(sedeDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SedeDtoExists(sedeDto.SedeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSedeDto", new { id = sedeDto.SedeId }, sedeDto);
        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSedeDto(int id)
        {
            var sedeDto = await _context.SedeDTO.FindAsync(id);
            if (sedeDto == null)
            {
                return NotFound();
            }

            _context.SedeDTO.Remove(sedeDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SedeDtoExists(int id)
        {
            return _context.SedeDTO.Any(e => e.SedeId == id);
        }
    }
}
