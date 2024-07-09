using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_management_system_api.Project
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }  
        public ProjectStatus? Status { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }

    public enum ProjectStatus
    {
        Active,
        Hold,
        Completed
    }
}
