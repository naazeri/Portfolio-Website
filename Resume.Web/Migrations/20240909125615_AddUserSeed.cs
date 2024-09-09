using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "FirstName", "IsActive", "LastName", "Mobile", "Password", "UpdateDate" },
                values: new object[] { 1, new DateTime(2024, 9, 9, 16, 26, 14, 561, DateTimeKind.Local).AddTicks(4711), "admin@example.com", "Admin", true, "Admin", "09123456789", "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E", new DateTime(2024, 9, 9, 16, 26, 14, 561, DateTimeKind.Local).AddTicks(4725) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
