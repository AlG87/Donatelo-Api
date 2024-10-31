using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.Donations
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public DonacionesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Donaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonacionDto>>> GetDonacionDTO()
        {
            return await _context.DonacionDTO.ToListAsync();
        }

        // GET: api/Donaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonacionDto>> GetDonacionDto(int id)
        {
            var donacionDto = await _context.DonacionDTO.FindAsync(id);

            if (donacionDto == null)
            {
                return NotFound();
            }

            return donacionDto;
        }

        // PUT: api/Donaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacionDto(int id, DonacionDto donacionDto)
        {
            if (id != donacionDto.DonacionId)
            {
                return BadRequest();
            }

            _context.Entry(donacionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionDtoExists(id))
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

        // POST: api/Donaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonacionDto>> PostDonacionDto(DonacionDto donacionDto)
        {
            _context.DonacionDTO.Add(donacionDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonacionDtoExists(donacionDto.DonacionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonacionDto", new { id = donacionDto.DonacionId }, donacionDto);
        }

        // DELETE: api/Donaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacionDto(int id)
        {
            var donacionDto = await _context.DonacionDTO.FindAsync(id);
            if (donacionDto == null)
            {
                return NotFound();
            }

            _context.DonacionDTO.Remove(donacionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionDtoExists(int id)
        {
            return _context.DonacionDTO.Any(e => e.DonacionId == id);
        }
    }
}
