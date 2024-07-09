using Microsoft.EntityFrameworkCore;


namespace project_management_system_api.Services.TeamMember
{
    using project_management_system_api.TeamMember;
    public interface IEmployeeOfTheYearService
    {
        Task<TeamMember> GetEmployeeOfTheYear();
    }

    public class EmployeeOfTheYearService : IEmployeeOfTheYearService
    {
        private readonly TeamDbContext _context;

        public EmployeeOfTheYearService(TeamDbContext context)
        {
            _context = context;
        }

        public async Task<TeamMember> GetEmployeeOfTheYear()
        {
            var employees = await _context.TeamMembers.ToListAsync();
            var employeeOfTheYear = employees.OrderByDescending(e => int.TryParse(e.ProjectsCompleted, out int projects) ? projects : 0)
                                            .FirstOrDefault();

            return employeeOfTheYear;
        }
    }

}
