

using BrinquedosAPI.Data;
using BrinquedosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrinquedosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrinquedosController : ControllerBase
    {
        private readonly BrinquedosContext _context;

        public BrinquedosController(BrinquedosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brinquedo>>> GetBrinquedos()
        {
            return await _context.TDS_TB_Brinquedos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brinquedo>> GetBrinquedo(int id)
        {
            var brinquedo = await _context.TDS_TB_Brinquedos.FindAsync(id);

            if (brinquedo == null)
            {
                return NotFound();
            }

            return brinquedo;
        }

        [HttpPost]
        public async Task<ActionResult<Brinquedo>> PostBrinquedo(Brinquedo brinquedo)
        {
            _context.TDS_TB_Brinquedos.Add(brinquedo);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrinquedo), new { id = brinquedo.Id_brinquedo }, brinquedo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrinquedo(int id, Brinquedo brinquedo)
        {
            if (id != brinquedo.Id_brinquedo)
            {
                return BadRequest();
            }

            _context.Entry(brinquedo).State = EntityState.Modified;

            try
            { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrinquedoExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrinquedo(int id)
        {
            var brinquedo = await _context.TDS_TB_Brinquedos.FindAsync(id);

            if (brinquedo == null)
            {
                return NotFound();
            }

            _context.TDS_TB_Brinquedos.Remove(brinquedo);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrinquedoExists(int id)
        {
            return _context.TDS_TB_Brinquedos.Any(e => e.Id_brinquedo == id);
        }
    }
}
