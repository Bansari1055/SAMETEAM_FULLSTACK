using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameTeamAPI.Data;
using SameTeamAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SameTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private readonly SameTeamDbContext _context;

        public ChoresController(SameTeamDbContext context)
        {
            _context = context;
        }

        // GET: api/Chores - Retrieve all chores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chore>>> GetChores()
        {
            return await _context.Chores.ToListAsync();
        }

        // GET: api/Chores/{id} - Retrieve a single chore by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);

            if (chore == null)
            {
                return NotFound();
            }

            return chore;
        }

        // POST: api/Chores - Create a new chore
        [HttpPost]
        public async Task<ActionResult<Chore>> PostChore([FromBody] Chore chore)
        {
            if (chore == null)
            {
                return BadRequest("Chore data is required.");
            }

            if (chore.AssignedToUserID == 0)
            {
                return BadRequest("AssignedToUserID is required.");
            }

            // Ensure AssignedToUser is null to prevent model binding issues
            chore.AssignedToUser = null;

            _context.Chores.Add(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChore), new { id = chore.ChoreID }, chore);
        }

        // PUT: api/Chores/{id} - Update an existing chore
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChore(int id, Chore chore)
        {
            if (id != chore.ChoreID)
            {
                return BadRequest();
            }

            _context.Entry(chore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreExists(id))
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

        // DELETE: api/Chores/{id} - Delete a chore by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }

            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoreExists(int id)
        {
            return _context.Chores.Any(e => e.ChoreID == id);
        }
    }
}
