using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedLeaveAllocationcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dbeeae1-543a-47c5-8f1f-21cca7535c11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a82dd791-3cc4-4a56-9039-a501d96ffd84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f69f9ed9-4c9f-4c5c-a982-d328c6b54c4e");

            migrationBuilder.RenameColumn(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                newName: "Days");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Days",
                table: "LeaveAllocations",
                newName: "NumberOfDays");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4dbeeae1-543a-47c5-8f1f-21cca7535c11", null, "Administrator", "Administrator" },
                    { "a82dd791-3cc4-4a56-9039-a501d96ffd84", null, "Supervisor", "Supervisor" },
                    { "f69f9ed9-4c9f-4c5c-a982-d328c6b54c4e", null, "Employee", "Employee" }
                });
        }
    }
}
