namespace project_management_system_api.Email
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime MeetingDate { get; set; }

    }
}
