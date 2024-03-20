using Microsoft.EntityFrameworkCore;
using project_management_system_api.TeamMember;

namespace project_management_system_api.TeamMember
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext() { }

        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options) { }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAOH654\\MSSQLSERVER02;Initial Catalog=master;Encrypt=false;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
