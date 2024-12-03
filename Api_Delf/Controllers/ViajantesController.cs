using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Delf.Models;
using Microsoft.AspNetCore.Cors;

namespace Api_Delf.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ViajantesController : ControllerBase
    {
        private readonly DbDelfContext _context;

        public ViajantesController(DbDelfContext context)
        {
            _context = context;
        }

        // GET: api/Viajantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viajante>>> GetViajantes()
        {
            return await _context.Viajantes!.ToListAsync();
        }

        // GET: api/Viajantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viajante>> GetViajante(int id)
        {
            var viajante = await _context.Viajantes!.FindAsync(id);

            if (viajante == null)
            {
                return NotFound();
            }

            return viajante;
        }

        // PUT: api/Viajantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajante(int id, Viajante viajante)
        {
            if (id != viajante.Id)
            {
                return BadRequest();
            }

            _context.Entry(viajante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajanteExists(id))
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

        // POST: api/Viajantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viajante>> PostViajante(Viajante viajante)
        {
            _context.Viajantes!.Add(viajante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViajante", new { id = viajante.Id }, viajante);
        }

        // DELETE: api/Viajantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViajante(int id)
        {
            var viajante = await _context.Viajantes!.FindAsync(id);
            if (viajante == null)
            {
                return NotFound();
            }

            _context.Viajantes.Remove(viajante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajanteExists(int id)
        {
            return _context.Viajantes!.Any(e => e.Id == id);
        }
    }
}
