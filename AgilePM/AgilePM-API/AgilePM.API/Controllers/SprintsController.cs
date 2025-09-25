using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilePM.API.Models;

namespace AgilePM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SprintsController : ControllerBase
    {
        private readonly AgilePmDbContext _context;

        public SprintsController(AgilePmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sprint>>> GetSprints()
        {
            return await _context.Sprints.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sprint>> GetSprint(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
                return NotFound();
            return sprint;
        }

        [HttpPost]
        public async Task<ActionResult<Sprint>> CreateSprint(Sprint sprint)
        {
            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSprint), new { id = sprint.Id }, sprint);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSprint(int id, Sprint sprint)
        {
            if (id != sprint.Id)
                return BadRequest();
            _context.Entry(sprint).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sprints.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSprint(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
                return NotFound();
            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
