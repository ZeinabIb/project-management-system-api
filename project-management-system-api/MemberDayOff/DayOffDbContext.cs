using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace project_management_system_api.MemberDayOff
{
    public class DayOffDbContext: DbContext
    {
        public DayOffDbContext() { }

        public DayOffDbContext(DbContextOptions<DayOffDbContext> options) : base(options) { }
        public DbSet<MemberDayOff> MemberDayOff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAOH654\\MSSQLSERVER02;Initial Catalog=master;Encrypt=false;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model relationships or constraints here if needed
        }
    }
}


