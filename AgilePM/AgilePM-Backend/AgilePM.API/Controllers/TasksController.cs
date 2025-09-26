using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilePM.API.Models;

namespace AgilePM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AgilePmDbContext _context;

        public TasksController(AgilePmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgilePM.API.Models.Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgilePM.API.Models.Task>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<AgilePM.API.Models.Task>> CreateTask(AgilePM.API.Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, AgilePM.API.Models.Task task)
        {
            if (id != task.Id)
                return BadRequest();
            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tasks.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("completed/count")]
        public async Task<ActionResult<object>> GetCompletedTasksCount()
        {
            var count = await _context.Tasks.CountAsync(t => t.Status == "Completado");
            return Ok(new { count });
        }
    }
}
