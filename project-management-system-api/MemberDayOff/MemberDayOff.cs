using System.ComponentModel.DataAnnotations;

namespace project_management_system_api.MemberDayOff
{
    public class MemberDayOff
    {
        [Key]
        public long MemberId { get; set; }
        public string FullName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public bool IsMakingUp { get; set; }
        public byte[] ReportImage { get; set; }
    }
}
