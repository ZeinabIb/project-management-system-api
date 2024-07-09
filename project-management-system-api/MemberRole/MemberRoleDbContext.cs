using Microsoft.EntityFrameworkCore;
using project_management_system_api.MemberRole;

namespace project_management_system_api.MemberRoleDbContext
{
    using project_management_system_api.MemberRoleDbContext;
    using project_management_system_api.MemberRole;
    public class MemberRoleDbContext : DbContext
    {
        public MemberRoleDbContext(DbContextOptions<MemberRoleDbContext> options) : base(options) { }

        public DbSet<MemberRole> MemberRole { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAOH654\\MSSQLSERVER02;Initial Catalog=master;Encrypt=false;Integrated Security=True");
            }
        }





    }
}
