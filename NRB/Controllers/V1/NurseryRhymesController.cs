using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryRhymesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NurseryRhymesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NurseryRhymes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseryRhyme>>> GetNurseryRhymes()
        {
            return await _context.NurseryRhymes.ToListAsync();
        }

        // GET: api/NurseryRhymes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NurseryRhyme>> GetNurseryRhyme(int id)
        {
            var nurseryRhyme = await _context.NurseryRhymes.FindAsync(id);

            if (nurseryRhyme == null)
            {
                return NotFound();
            }

            return nurseryRhyme;
        }

        // PUT: api/NurseryRhymes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurseryRhyme(int id, NurseryRhyme nurseryRhyme)
        {
            if (id != nurseryRhyme.Id)
            {
                return BadRequest();
            }

            _context.Entry(nurseryRhyme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseryRhymeExists(id))
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

        // POST: api/NurseryRhymes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NurseryRhyme>> PostNurseryRhyme(NurseryRhyme nurseryRhyme)
        {
            _context.NurseryRhymes.Add(nurseryRhyme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurseryRhyme", new { id = nurseryRhyme.Id }, nurseryRhyme);
        }

        // DELETE: api/NurseryRhymes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NurseryRhyme>> DeleteNurseryRhyme(int id)
        {
            var nurseryRhyme = await _context.NurseryRhymes.FindAsync(id);
            if (nurseryRhyme == null)
            {
                return NotFound();
            }

            _context.NurseryRhymes.Remove(nurseryRhyme);
            await _context.SaveChangesAsync();

            return nurseryRhyme;
        }

        private bool NurseryRhymeExists(int id)
        {
            return _context.NurseryRhymes.Any(e => e.Id == id);
        }
    }
}
