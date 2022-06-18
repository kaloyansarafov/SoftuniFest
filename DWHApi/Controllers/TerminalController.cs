using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DWHApi;
using DWHApi.Models;

namespace DWHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly DWHDbContext _context;

        public TerminalController(DWHDbContext context)
        {
            _context = context;
        }

        // GET: api/Terminal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terminal>>> GetTerminals()
        {
            if (_context.Terminals == null)
            {
                return NotFound();
            }

            return await _context.Terminals.ToListAsync();
        }

        // GET: api/Terminal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Terminal>> GetTerminal(int id)
        {
            if (_context.Terminals == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminals.FindAsync(id);

            if (terminal == null)
            {
                return NotFound();
            }

            return terminal;
        }

        // PUT: api/Terminal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerminal(int id, Terminal terminal)
        {
            if (id != terminal.Id)
            {
                return BadRequest();
            }

            _context.Entry(terminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminalExists(id))
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

        // POST: api/Terminal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Terminal>> PostTerminal(Terminal terminal)
        {
            if (_context.Terminals == null)
            {
                return Problem("Entity set 'DWHDbContext.Terminals'  is null.");
            }

            _context.Terminals.Add(terminal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerminal", new { id = terminal.Id }, terminal);
        }

        // DELETE: api/Terminal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerminal(int id)
        {
            if (_context.Terminals == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminals.FindAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }

            _context.Terminals.Remove(terminal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TerminalExists(int id)
        {
            return (_context.Terminals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}