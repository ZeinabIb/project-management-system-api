using System.ComponentModel.DataAnnotations;

namespace project_management_system_api.MemberRole
{
    public class MemberRole
    {
        [Key]
        public int RoleId { get; set; }


        public string MemberName { get; set; }


        public string Role { get; set; }


        public string ProjectName { get; set; }
    }
}
