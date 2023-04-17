using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerAPI;
using ProjectTrackerAPI.NET6.ProjectTrackerAPI;

namespace ProjectTrackerAPI.NET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailController : ControllerBase
    {
        private readonly NET6DbContext _context;

        private TaskDetailController(NET6DbContext context)
        {
            _context = context;
        }

        // GET: api/TaskDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetail>>> GetTaskDetails()
        {
          if (_context.TaskDetails == null)
          {
              return NotFound();
          }
            return await _context.TaskDetails.ToListAsync();
        }

        // GET: api/TaskDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetail>> GetTaskDetails(int id)
        {
          if (_context.TaskDetails == null)
          {
              return NotFound();
          }
            var taskDetails = await _context.TaskDetails.FindAsync(id);

            if (taskDetails == null)
            {
                return NotFound();
            }

            return taskDetails;
        }

        // PUT: api/TaskDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetails(int id, TaskDetail taskDetails)
        {
            if (id != taskDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDetailsExists(id))
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

        // POST: api/TaskDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDetail>> PostTaskDetails(TaskDetail taskDetails)
        {
          if (_context.TaskDetails == null)
          {
              return Problem("Entity set 'NET6DbContext.TaskDetails'  is null.");
          }
            _context.TaskDetails.Add(taskDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskDetails", new { id = taskDetails.Id }, taskDetails);
        }

        // DELETE: api/TaskDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDetails(int id)
        {
            if (_context.TaskDetails == null)
            {
                return NotFound();
            }
            var taskDetails = await _context.TaskDetails.FindAsync(id);
            if (taskDetails == null)
            {
                return NotFound();
            }

            _context.TaskDetails.Remove(taskDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskDetailsExists(int id)
        {
            return (_context.TaskDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
