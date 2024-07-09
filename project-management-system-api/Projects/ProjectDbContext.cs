/*using Microsoft.EntityFrameworkCore;
using project_management_system_api.Project;
using project_management_system_api.Tasks;

namespace project_management_system_api.Project
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() { }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Task>().ToTable("Task");

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId);
        }
    }
}
*/