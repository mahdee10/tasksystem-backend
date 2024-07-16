using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class updateEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da030d5-e2c3-4d83-80a0-f5ca4fafaf49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637fb914-e170-41cf-8f38-5d4578a2de67");

            migrationBuilder.AddColumn<bool>(
                name: "IsReminded",
                table: "event",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190091ed-5328-4e17-81ac-e5a81332f8d2", null, "Admin", "ADMIN" },
                    { "2db4138b-9ab0-4166-87b2-89e0a40fcfb8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190091ed-5328-4e17-81ac-e5a81332f8d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db4138b-9ab0-4166-87b2-89e0a40fcfb8");

            migrationBuilder.DropColumn(
                name: "IsReminded",
                table: "event");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1da030d5-e2c3-4d83-80a0-f5ca4fafaf49", null, "Admin", "ADMIN" },
                    { "637fb914-e170-41cf-8f38-5d4578a2de67", null, "User", "USER" }
                });
        }
    }
}
