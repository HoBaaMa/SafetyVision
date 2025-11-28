using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafetyVision.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartmentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("240f91ce-480f-4218-8958-a674bd86ba45"), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Health and Safety" },
                    { new Guid("5ca5a204-016f-4613-95f3-f32c934bbb19"), new DateTime(2025, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workplace Safety Compliance" },
                    { new Guid("d28ea0c5-0d08-4b5a-a509-669011364ce4"), new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environmental Protection" },
                    { new Guid("f837bfa0-53c9-4ba8-ae27-009008a401f5"), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fire Safety and Emergency Response" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("240f91ce-480f-4218-8958-a674bd86ba45"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("5ca5a204-016f-4613-95f3-f32c934bbb19"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d28ea0c5-0d08-4b5a-a509-669011364ce4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f837bfa0-53c9-4ba8-ae27-009008a401f5"));
        }
    }
}
