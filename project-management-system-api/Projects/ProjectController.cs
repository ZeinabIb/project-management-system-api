using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_management_system_api.Project;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_management_system_api.Project

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsTasksDbContext _context;

        public ProjectsController(ProjectsTasksDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/Projects
        // POST: api/Projects/{id}/{projectName}/{projectDescription}/{fromDate}/{toDate}/{status}/{projectOwner}
        // POST: api/Projects/{projectName}/{projectDescription}/{fromDate}/{toDate}/{status}/{projectOwner}
        [Authorize]
        [HttpPost("{projectName}/{projectDescription}/{fromDate}/{toDate}/{status}/{projectOwner}")]
        public async Task<ActionResult<Project>> PostProject(string projectName, string projectDescription, DateTime? fromDate, DateTime? toDate, ProjectStatus? status, string projectOwner)
        {
            var project = new Project
            {
                Name = projectName,
                Description = projectDescription,
                FromDate = fromDate,
                ToDate = toDate,
                Status = status,
                Owner = projectOwner
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
        }

        // PUT: api/Projects/5

        [HttpPut("{id}")]
        [Authorize(Roles = "teamLead,admin")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // DELETE: api/Projects/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }

        // GET: api/Projects/ByName/{projectName}

        [HttpGet("ByName/{projectName}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByName(string projectName)
        {
            var projects = await _context.Projects.Where(p => p.Name.Contains(projectName)).ToListAsync();

            if (projects == null || projects.Count == 0)
            {
                return NotFound();
            }

            return projects;
        }
    }
}
