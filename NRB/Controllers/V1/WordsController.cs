﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models.Data;

namespace Capstone.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            return await _context.Words.ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
            var word = await _context.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
