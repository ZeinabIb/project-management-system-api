using System.ComponentModel.DataAnnotations;

namespace project_management_system_api.TeamMember
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  Position { get; set; }
        public string ProjectsCompleted { get; set; }
        public string MeetingsAttended { get; set; }
        public string IssuesResolved { get;  set; }


    }
}
