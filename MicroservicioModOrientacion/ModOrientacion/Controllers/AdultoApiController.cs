using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModOrientacion.Models;
using ModOrientacion.Data;

namespace ModOrientacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdultoApiController : ControllerBase
    {
        private readonly ModOrientacionContext _context;

        public AdultoApiController(ModOrientacionContext context)
        {
            _context = context;
        }

        // GET: api/AdultoApi
        [HttpGet("ListarAdultos")]
        public async Task<ActionResult<IEnumerable<Adulto>>> GetAdultos()
        {
            return await _context.Adultos.ToListAsync();
        }

        // GET: api/AdultoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adulto>> GetAdulto(int id)
        {
            var adulto = await _context.Adultos.FindAsync(id);

            if (adulto == null)
            {
                return NotFound();
            }

            return adulto;
        }

        // POST: api/AdultoApi
        [HttpPost("RegistrarNuevoAdulto")]
        public async Task<ActionResult<Adulto>> PostAdulto(Adulto adulto)
        {
            _context.Adultos.Add(adulto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdulto", new { id = adulto.IdAdulto }, adulto);
        }

        // PUT: api/AdultoApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdulto(int id, Adulto adulto)
        {
            if (id != adulto.IdAdulto)
            {
                return BadRequest();
            }

            _context.Entry(adulto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdultoExists(id))
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

        // DELETE: api/AdultoApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdulto(int id)
        {
            var adulto = await _context.Adultos.FindAsync(id);
            if (adulto == null)
            {
                return NotFound();
            }

            _context.Adultos.Remove(adulto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdultoExists(int id)
        {
            return _context.Adultos.Any(e => e.IdAdulto == id);
        }
    }
}