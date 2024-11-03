using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonateloApiRest.Models;

namespace DonateloApiRest.Controllers.Rol
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoltypesController : ControllerBase
    {
        private readonly DonateloDbOficialContext _context;

        public RoltypesController(DonateloDbOficialContext context)
        {
            _context = context;
        }

        // GET: api/Roltypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roltype>>> GetRoltypes()
        {
            return await _context.Roltypes.ToListAsync();
        }

        // GET: api/Roltypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roltype>> GetRoltype(int id)
        {
            var roltype = await _context.Roltypes.FindAsync(id);

            if (roltype == null)
            {
                return NotFound();
            }

            return roltype;
        }

        // PUT: api/Roltypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoltype(int id, Roltype roltype)
        {
            if (id != roltype.RolId)
            {
                return BadRequest();
            }

            _context.Entry(roltype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoltypeExists(id))
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

        // POST: api/Roltypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roltype>> PostRoltype(Roltype roltype)
        {
            _context.Roltypes.Add(roltype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoltype", new { id = roltype.RolId }, roltype);
        }

        // DELETE: api/Roltypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoltype(int id)
        {
            var roltype = await _context.Roltypes.FindAsync(id);
            if (roltype == null)
            {
                return NotFound();
            }

            _context.Roltypes.Remove(roltype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoltypeExists(int id)
        {
            return _context.Roltypes.Any(e => e.RolId == id);
        }
    }
}
