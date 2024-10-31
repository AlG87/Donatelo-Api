using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donatelo.Api.Context;
using Donatelo.Api.Entities;

namespace Donatelo.Api.Controllers.Rol
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolTypeController : ControllerBase
    {
        private readonly AppdbContext _context;

        public RolTypeController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/RolType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolTypeDto>>> GetrolTypeDtos()
        {
            return await _context.rolTypeDtos.ToListAsync();
        }

        // GET: api/RolType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolTypeDto>> GetRolTypeDto(int id)
        {
            var rolTypeDto = await _context.rolTypeDtos.FindAsync(id);

            if (rolTypeDto == null)
            {
                return NotFound();
            }

            return rolTypeDto;
        }

        // PUT: api/RolType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolTypeDto(int id, RolTypeDto rolTypeDto)
        {
            if (id != rolTypeDto.Rolid)
            {
                return BadRequest();
            }

            _context.Entry(rolTypeDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolTypeDtoExists(id))
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

        // POST: api/RolType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolTypeDto>> PostRolTypeDto(RolTypeDto rolTypeDto)
        {
            _context.rolTypeDtos.Add(rolTypeDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolTypeDtoExists(rolTypeDto.Rolid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolTypeDto", new { id = rolTypeDto.Rolid }, rolTypeDto);
        }

        // DELETE: api/RolType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolTypeDto(int id)
        {
            var rolTypeDto = await _context.rolTypeDtos.FindAsync(id);
            if (rolTypeDto == null)
            {
                return NotFound();
            }

            _context.rolTypeDtos.Remove(rolTypeDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolTypeDtoExists(int id)
        {
            return _context.rolTypeDtos.Any(e => e.Rolid == id);
        }
    }
}
