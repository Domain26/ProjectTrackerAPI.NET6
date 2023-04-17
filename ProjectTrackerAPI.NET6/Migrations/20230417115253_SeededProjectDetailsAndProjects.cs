using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectTrackerAPI.NET6.Migrations
{
    /// <inheritdoc />
    public partial class SeededProjectDetailsAndProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "ProjectDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ProjectDetails",
                columns: new[] { "Id", "Country", "Description", "EndDate", "Name", "StartDate", "Status", "Task", "TaskId" },
                values: new object[,]
                {
                    { 1, "USA", "Description A", new DateTime(2023, 4, 24, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4406), "Project A", new DateTime(2023, 4, 17, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4390), "Active", "Task A", 0 },
                    { 2, "Canada", "Description B", new DateTime(2023, 5, 1, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4414), "Project B", new DateTime(2023, 4, 17, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4413), "Inactive", "Task B", 0 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Country", "Description", "EndDate", "Name", "Responsible", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "USA", "Description A", new DateTime(2023, 4, 24, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4496), "Project A", "Person A", new DateTime(2023, 4, 17, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4495), "Active", "Type A" },
                    { 2, "Canada", "Description B", new DateTime(2023, 5, 1, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4498), "Project B", "Person B", new DateTime(2023, 4, 17, 12, 52, 52, 958, DateTimeKind.Local).AddTicks(4498), "Inactive", "Type B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Task",
                table: "ProjectDetails");
        }
    }
}
