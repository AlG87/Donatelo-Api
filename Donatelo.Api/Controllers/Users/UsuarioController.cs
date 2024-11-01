using Donatelo.Api.Context;
using Donatelo.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Donatelo.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppdbContext _context;

        public UsuarioController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarioDTO()
        {
            return await _context.UsuarioDTO.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioDto(int id)
        {
            var usuarioDto = await _context.UsuarioDTO.FindAsync(id);

            if (usuarioDto == null)
            {
                return NotFound();
            }

            return usuarioDto;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioDto(int id, UsuarioDto usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioDtoExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuarioDto(UsuarioDto usuarioDto)
        {
            _context.UsuarioDTO.Add(usuarioDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioDtoExists(usuarioDto.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioDto", new { id = usuarioDto.UsuarioId }, usuarioDto);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioDto(int id)
        {
            var usuarioDto = await _context.UsuarioDTO.FindAsync(id);
            if (usuarioDto == null)
            {
                return NotFound();
            }

            _context.UsuarioDTO.Remove(usuarioDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioDtoExists(int id)
        {
            return _context.UsuarioDTO.Any(e => e.UsuarioId == id);
        }
    }
}
