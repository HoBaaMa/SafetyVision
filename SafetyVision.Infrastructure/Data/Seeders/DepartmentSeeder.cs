using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Seeders
{
    internal class DepartmentSeeder
    {
        public static void SeedDepartments (ModelBuilder modelBuilder)
        {
            var departments = new List<Department>
            {
                new Department
                {
                    Id = Guid.Parse("240F91CE-480F-4218-8958-A674BD86BA45"),
                    Name = "Health and Safety",
                    CreatedAt = DateTime.Parse("2025-01-20")
                },
                new Department
                {
                    Id = Guid.Parse("D28EA0C5-0D08-4B5A-A509-669011364CE4"),
                    Name = "Environmental Protection",
                    CreatedAt = DateTime.Parse("2025-07-18")
                },
                new Department
                {
                    Id = Guid.Parse("F837BFA0-53C9-4BA8-AE27-009008A401F5"),
                    Name = "Fire Safety and Emergency Response",
                    CreatedAt = DateTime.Parse("2025-10-10")
                },
                new Department
                {
                    Id = Guid.Parse("5CA5A204-016F-4613-95F3-F32C934BBB19"),
                    Name = "Workplace Safety Compliance",
                    CreatedAt = DateTime.Parse("2025-11-29")
                }
            };

            modelBuilder.Entity<Department>().HasData(departments);
        }
    }
}
