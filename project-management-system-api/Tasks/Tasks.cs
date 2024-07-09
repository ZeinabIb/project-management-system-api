using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using project_management_system_api.Project;

namespace project_management_system_api.Project
{

    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public TaskStatus Status { get; set; }

     
        public int ProjectId { get; set; }

      
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }

    public enum TaskStatus
    {
        Done,
        Active,
        QA
    }
}
