/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_management_system_api.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project_management_system_api.Project;
namespace project_management_system_api.Tasks

{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksDbContext _context;
        private readonly ProjectDbContext _projectContext; 

        public TasksController(TasksDbContext context, ProjectDbContext projectContext)
        {
            _context = context;
            _projectContext = projectContext;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetTasks(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }
        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
            var project = await _projectContext.Project.FindAsync(task.ProjectId); // Access Project from ProjectDbContext
            if (project == null)
            {
                return BadRequest($"Project with ID {task.ProjectId} not found.");
            }

            task.Project = project; // Ensure that the Project property is properly assigned

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTasks), new { id = task.TaskId }, task);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, Task task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
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

        // DELETE: api/Tasks/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

/*     private bool TasksExists(int id)
     {
         return _context.Tasks.Any(e => e.TaskId == id);
     }

     // GET: api/Tasks/Active
     [HttpGet("Active")]
     public async Task<ActionResult<IEnumerable<Task>>> GetActiveTasks()
     {
         var activeTasks = await _context.Tasks.Where(t => t.Status == Task.TaskStatus.Active).ToListAsync();
         return activeTasks;
     }

     // GET: api/Tasks/ByProject/{projectId}
     [HttpGet("ByProject/{projectId}")]
     public async Task<ActionResult<IEnumerable<Task>>> GetTasksByProject(int projectId)
     {
         var tasksByProject = await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
         if (tasksByProject == null)
         {
             return NotFound($"No tasks found for project with ID {projectId}");
         }
         return tasksByProject;
     }
     [HttpGet("Done")]
     public async Task<ActionResult<IEnumerable<Task>>> GetDoneTasks()
     {
         var doneTasks = await _context.Tasks.Where(t => t.Status == Task.TaskStatus.Done).ToListAsync();
         return doneTasks;
     }

     [HttpGet("QA")]
     public async Task<ActionResult<IEnumerable<Task>>> GetQATasks()
     {
         var QATasks = await _context.Tasks.Where(t => t.Status == Task.TaskStatus.QA).ToListAsync();
         return QATasks;
     }

 }





}*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_management_system_api.Project;
using System.Collections.Generic;
using System.Linq;


namespace project_management_system_api.Tasks
{

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ProjectsTasksDbContext _context;

        public TasksController(ProjectsTasksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<project_management_system_api.Project.Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<project_management_system_api.Project.Task>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<project_management_system_api.Project.Task>> PostTask(project_management_system_api.Project.Task task)
        {
            var project = await _context.Projects.FindAsync(task.ProjectId);
            if (project == null)
            {
                return BadRequest($"Project with ID {task.ProjectId} not found.");
            }

            task.Project = project;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, project_management_system_api.Project.Task task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }

    }
}