using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class sad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190091ed-5328-4e17-81ac-e5a81332f8d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db4138b-9ab0-4166-87b2-89e0a40fcfb8");

            migrationBuilder.AddColumn<bool>(
                name: "IsReminded",
                table: "registeredglobalevent",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "354801ed-ac7c-4407-a3d4-57c48220af63", null, "Admin", "ADMIN" },
                    { "69542378-87d9-4059-8b8f-4276ac5deb22", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354801ed-ac7c-4407-a3d4-57c48220af63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69542378-87d9-4059-8b8f-4276ac5deb22");

            migrationBuilder.DropColumn(
                name: "IsReminded",
                table: "registeredglobalevent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190091ed-5328-4e17-81ac-e5a81332f8d2", null, "Admin", "ADMIN" },
                    { "2db4138b-9ab0-4166-87b2-89e0a40fcfb8", null, "User", "USER" }
                });
        }
    }
}
