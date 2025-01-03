﻿namespace ProjectTrackerAPI.NET6.ProjectTrackerAPI
{
    public class Projects
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Responsible { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }

    }
}
