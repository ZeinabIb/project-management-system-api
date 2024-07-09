using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using project_management_system_api.TeamMember;

namespace project_management_system_api.TeamMember
{
    public class TeamMemberRole
    {
        [Key]
        public int Id { get; set; }

        public int MemberId { get; set; }
        public TeamMember TeamMember { get; set; }

        public string Role { get; set; } 
    }
}
