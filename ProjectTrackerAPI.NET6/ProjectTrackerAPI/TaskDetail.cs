namespace ProjectTrackerAPI.NET6.ProjectTrackerAPI
{
    public class TaskDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        // Navigation property to the parent ProjectDetails entity
        public ICollection<ProjectDetails>? ProjectDetails { get; set; }
    }
}