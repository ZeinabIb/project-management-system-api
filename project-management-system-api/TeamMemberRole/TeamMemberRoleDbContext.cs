using Microsoft.EntityFrameworkCore;
using project_management_system_api.TeamMember;

namespace project_management_system_api.TeamMemberRole
{
    public class TeamMemberRoleDbContext : DbContext
    {
        public TeamMemberRoleDbContext() { }
        public TeamMemberRoleDbContext(DbContextOptions<TeamMemberRoleDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMemberRoleDbContext> TeamMemberRoles { get; set; }
    }
}
