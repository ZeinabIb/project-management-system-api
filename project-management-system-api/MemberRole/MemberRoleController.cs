using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_management_system_api.MemberRole
{
    using project_management_system_api.MemberRoleDbContext;

    [Route("api/[controller]")]
    [ApiController]
    public class MemberRoleController : ControllerBase
    {
        private readonly MemberRoleDbContext _context;

        public MemberRoleController(MemberRoleDbContext context)
        {
            _context = context;
        }

        // GET: api/MemberRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberRole>>> GetMemberRoles()
        {
            return await _context.MemberRole.ToListAsync();
        }

        // GET: api/MemberRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberRole>> GetMemberRole(int id)
        {
            var memberRole = await _context.MemberRole.FindAsync(id);

            if (memberRole == null)
            {
                return NotFound();
            }

            return memberRole;
        }

        // GET: api/MemberRole/ByName/{name}
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<IEnumerable<MemberRole>>> GetMemberRolesByName(string name)
        {
            var memberRoles = await _context.MemberRole.Where(m => m.ProjectName == name).ToListAsync();

            if (memberRoles == null || !memberRoles.Any())
            {
                return NotFound();
            }

            return memberRoles;
        }

        // POST: api/MemberRole
        [HttpPost]
        public async Task<ActionResult<MemberRole>> PostMemberRole(MemberRole memberRole)
        {
            _context.MemberRole.Add(memberRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMemberRole), new { id = memberRole.RoleId }, memberRole);
        }

        // PUT: api/MemberRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberRole(int id, MemberRole memberRole)
        {
            if (id != memberRole.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(memberRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberRoleExists(id))
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

        // DELETE: api/MemberRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberRole(int id)
        {
            var memberRole = await _context.MemberRole.FindAsync(id);
            if (memberRole == null)
            {
                return NotFound();
            }

            _context.MemberRole.Remove(memberRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberRoleExists(int id)
        {
            return _context.MemberRole.Any(e => e.RoleId == id);
        }
    }
}
