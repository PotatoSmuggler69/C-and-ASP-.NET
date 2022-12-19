using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Model;

namespace WebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketersController : ControllerBase
    {
        private readonly WebAPI_1Context _context;

        public CricketersController(WebAPI_1Context context)
        {
            _context = context;
        }

        // GET: api/Cricketers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cricketer>>> GetCricketer()
        {
            return await _context.Cricketer.ToListAsync();
        }

        // GET: api/Cricketers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cricketer>> GetCricketer(int id)
        {
            var cricketer = await _context.Cricketer.FindAsync(id);

            if (cricketer == null)
            {
                return NotFound();
            }

            return cricketer;
        }

        // PUT: api/Cricketers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCricketer(int id, Cricketer cricketer)
        {
            if (id != cricketer.ID)
            {
                return BadRequest();
            }

            _context.Entry(cricketer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CricketerExists(id))
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

        // POST: api/Cricketers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cricketer>> PostCricketer(Cricketer cricketer)
        {
            _context.Cricketer.Add(cricketer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCricketer", new { id = cricketer.ID }, cricketer);
        }

        // DELETE: api/Cricketers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCricketer(int id)
        {
            var cricketer = await _context.Cricketer.FindAsync(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            _context.Cricketer.Remove(cricketer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CricketerExists(int id)
        {
            return _context.Cricketer.Any(e => e.ID == id);
        }
    }
}
