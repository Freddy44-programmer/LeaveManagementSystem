using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40f2092e-e573-4962-9f5e-dc0cee44c609");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e957678-9875-4264-8239-162cefb21f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6491ea4b-1435-4c10-9ac9-c740ab447792");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "298544eb-79ff-4b3c-b261-96d65bd1d86f", null, "Supervisor", "Supervisor" },
                    { "3671fbe4-732e-4f91-8f14-72f7667e860e", null, "Employee", "Employee" },
                    { "f03883d7-4fc1-4f65-9521-28c81dddf316", null, "Administrator", "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298544eb-79ff-4b3c-b261-96d65bd1d86f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3671fbe4-732e-4f91-8f14-72f7667e860e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f03883d7-4fc1-4f65-9521-28c81dddf316");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40f2092e-e573-4962-9f5e-dc0cee44c609", null, "Administrator", "Administrator" },
                    { "4e957678-9875-4264-8239-162cefb21f15", null, "Employee", "Employee" },
                    { "6491ea4b-1435-4c10-9ac9-c740ab447792", null, "Supervisor", "Supervisor" }
                });
        }
    }
}
