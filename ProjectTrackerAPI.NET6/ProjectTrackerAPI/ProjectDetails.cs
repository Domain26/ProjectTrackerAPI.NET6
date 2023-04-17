using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrackerAPI.NET6.ProjectTrackerAPI
{
    public class ProjectDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("TaskDetails")]
        public int TaskId { get; set; }
        public TaskDetail? TaskDetails { get; set; }
        public string? Task { get; internal set; }
    }
}

