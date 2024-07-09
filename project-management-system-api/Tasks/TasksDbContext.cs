/*using Microsoft.EntityFrameworkCore;
using project_management_system_api.Project; 

namespace project_management_system_api.Tasks
{
    using project_management_system_api.Tasks;
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAOH654\\MSSQLSERVER02;Initial Catalog=master;Encrypt=false;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Task and Project
            modelBuilder.Entity<Tasks.Task>()
                .HasOne(t => t.Project)       // Each task has one project
                .WithMany(p => p.Tasks)       // Each project can have many tasks
                .HasForeignKey(t => t.ProjectId); // Foreign key property in Task entity
        }


    }
}
*/