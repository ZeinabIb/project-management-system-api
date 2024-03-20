using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_management_system_api.TeamMember
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly TeamDbContext _context;

        public TeamMemberController(TeamDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMember
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembersList()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        // GET: api/TeamMember/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return teamMember;
        }

        // GET: api/TeamMember/GetByName?name=JohnDoe
        [HttpGet("GetByName")]
        public async Task<ActionResult<TeamMember>> GetTeamMemberByName(string name)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(m => m.FullName == name);

            if (teamMember == null)
            {
                return NotFound();
            }

            return teamMember;
        }

        // POST: api/TeamMember
        [HttpPost]
        public async Task<ActionResult<TeamMember>> CreateTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.MemberId }, teamMember);
        }

        // PUT: api/TeamMember/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamMember(int id, TeamMember teamMember)
        {
            if (id != teamMember.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
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

        // DELETE: api/TeamMember/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //  Get all team members who completed more than a specified number of projects
        [HttpGet("CompletedMoreThanXProjects")]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembersCompletedMoreThanXProjects(int numberOfProjects)
        {
            var members = await _context.TeamMembers.ToListAsync();

            var filteredMembers = members.Where(m => int.TryParse(m.ProjectsCompleted, out _) && int.Parse(m.ProjectsCompleted) > numberOfProjects).ToList();

            if (filteredMembers == null || filteredMembers.Count == 0)
            {
                return NotFound();
            }

            return Ok(filteredMembers);
        }

        // Get all team members who attended less than a specified number of meetings
        [HttpGet("AttendedLessThanXMeetings")]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembersAttendedLessThanXMeetings(int numberOfMeetings)
        {
            var members = await _context.TeamMembers.ToListAsync();

            var filteredMembers = members.Where(m => int.TryParse(m.MeetingsAttended, out _) && int.Parse(m.MeetingsAttended) < numberOfMeetings).ToList();

            if (filteredMembers == null || filteredMembers.Count == 0)
            {
                return NotFound();
            }

            return Ok(filteredMembers);
        }


        private bool TeamMemberExists(int id)
        {
            return _context.TeamMembers.Any(e => e.MemberId == id);
        }
    }
}
