using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingExtraFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09d37476-319e-4578-b2e5-9073f5147954");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12526877-d6ec-4aaa-88b5-3be2a538ca42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61f76d83-720b-404c-a581-10ca1619899f");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f4031a2-d791-4528-83ad-5901dd847264", null, "Employee", "Employee" },
                    { "ae5f9e99-8e85-4e46-a5fb-89743eea47c7", null, "Supervisor", "Supervisor" },
                    { "d9991213-7d98-40ac-856f-71e8cf4e1596", null, "Administrator", "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4031a2-d791-4528-83ad-5901dd847264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5f9e99-8e85-4e46-a5fb-89743eea47c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9991213-7d98-40ac-856f-71e8cf4e1596");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09d37476-319e-4578-b2e5-9073f5147954", null, "Supervisor", "Supervisor" },
                    { "12526877-d6ec-4aaa-88b5-3be2a538ca42", null, "Administrator", "Administrator" },
                    { "61f76d83-720b-404c-a581-10ca1619899f", null, "Employee", "Employee" }
                });
        }
    }
}
