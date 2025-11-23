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
    public class FichaOriApiController : ControllerBase
    {
        private readonly ModOrientacionContext _context;

        public FichaOriApiController(ModOrientacionContext context)
        {
            _context = context;
        }

        // GET: api/FichaOriApi
        [HttpGet("ListarFichas")]
        public async Task<ActionResult<IEnumerable<FichaOri>>> GetFichas()
        {
            // Incluimos los datos del Adulto relacionado
            return await _context.Fichas.Include(f => f.adulto).ToListAsync();
        }

        // GET: api/FichaOriApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FichaOri>> GetFichaOri(int id)
        {
            var fichaOri = await _context.Fichas
                                         .Include(f => f.adulto)
                                         .FirstOrDefaultAsync(f => f.CodFicha == id);

            if (fichaOri == null)
            {
                return NotFound();
            }

            return fichaOri;
        }

        // POST: api/FichaOriApi
        [HttpPost("RegistrarNuevaFicha")]
        public async Task<ActionResult<FichaOri>> PostFichaOri(FichaOri fichaOri)
        {
            // Validar que el adulto existe antes de guardar (opcional, pero recomendado)
            var adultoExiste = await _context.Adultos.AnyAsync(a => a.IdAdulto == fichaOri.IdAdulto);
            if (!adultoExiste)
            {
                return BadRequest("El ID del adulto especificado no existe.");
            }

            _context.Fichas.Add(fichaOri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFichaOri", new { id = fichaOri.CodFicha }, fichaOri);
        }

        // PUT: api/FichaOriApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFichaOri(int id, FichaOri fichaOri)
        {
            if (id != fichaOri.CodFicha)
            {
                return BadRequest();
            }

            _context.Entry(fichaOri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaOriExists(id))
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

        // DELETE: api/FichaOriApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFichaOri(int id)
        {
            var fichaOri = await _context.Fichas.FindAsync(id);
            if (fichaOri == null)
            {
                return NotFound();
            }

            _context.Fichas.Remove(fichaOri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FichaOriExists(int id)
        {
            return _context.Fichas.Any(e => e.CodFicha == id);
        }
    }
}