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
    public class ArticuloCantidadesController : ControllerBase
    {
        private readonly DbDelfContext _context;

        public ArticuloCantidadesController(DbDelfContext context)
        {
            _context = context;
        }

        // GET: api/ArticuloCantidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloCantidade>>> GetArticuloCantidades()
        {
            return await _context.ArticuloCantidades!.ToListAsync();
        }

        // GET: api/ArticuloCantidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloCantidade>> GetArticuloCantidade(int id)
        {
            var articuloCantidade = await _context.ArticuloCantidades!.FindAsync(id);

            if (articuloCantidade == null)
            {
                return NotFound();
            }

            return articuloCantidade;
        }

        // PUT: api/ArticuloCantidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticuloCantidade(int id, ArticuloCantidade articuloCantidade)
        {
            if (id != articuloCantidade.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(articuloCantidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloCantidadeExists(id))
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

        // POST: api/ArticuloCantidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticuloCantidade>> PostArticuloCantidade(ArticuloCantidade articuloCantidade)
        {
            _context.ArticuloCantidades!.Add(articuloCantidade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticuloCantidadeExists(articuloCantidade.PedidoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticuloCantidade", new { id = articuloCantidade.PedidoId }, articuloCantidade);
        }

        // DELETE: api/ArticuloCantidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticuloCantidade(int id)
        {
            var articuloCantidade = await _context.ArticuloCantidades!.FindAsync(id);
            if (articuloCantidade == null)
            {
                return NotFound();
            }

            _context.ArticuloCantidades.Remove(articuloCantidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloCantidadeExists(int id)
        {
            return _context.ArticuloCantidades!.Any(e => e.PedidoId == id);
        }
    }
}
