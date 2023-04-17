using Microsoft.EntityFrameworkCore;
using ProjectTrackerAPI.NET6.ProjectTrackerAPI;

namespace ProjectTrackerAPI
{
    internal class NET6DbContext : DbContext
    {
        public NET6DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<ProjectDetails>().HasKey(p => p.Id);
            modelBuilder.Entity<Projects>().HasKey(p => p.Id);

            // Seed initial data
            modelBuilder.Entity<ProjectDetails>().HasData(
                new ProjectDetails { Id = 1, Name = "Project A", Description = "Description A", Country = "USA", Task = "Task A", Status = "Active", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) },
                new ProjectDetails { Id = 2, Name = "Project B", Description = "Description B", Country = "Canada", Task = "Task B", Status = "Inactive", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14) }
            );

            modelBuilder.Entity<Projects>().HasData(
                new Projects { Id = 1, Name = "Project A", Type = "Type A", Description = "Description A", Country = "USA", Responsible = "Person A", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Status = "Active" },
                new Projects { Id = 2, Name = "Project B", Type = "Type B", Description = "Description B", Country = "Canada", Responsible = "Person B", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14), Status = "Inactive" }
            );
        }

        public DbSet<ProjectTrackerAPI.NET6.ProjectTrackerAPI.TaskDetail>? TaskDetails { get; set; }
    }
}
