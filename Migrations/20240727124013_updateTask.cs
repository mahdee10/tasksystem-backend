using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class updateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354801ed-ac7c-4407-a3d4-57c48220af63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69542378-87d9-4059-8b8f-4276ac5deb22");

            migrationBuilder.AddColumn<bool>(
                name: "IsReminded",
                table: "task",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dedaba3-072d-4e46-bf71-e12a99bea67f", null, "Admin", "ADMIN" },
                    { "6924cd31-fca0-4e9a-818c-159e31e2221a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dedaba3-072d-4e46-bf71-e12a99bea67f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6924cd31-fca0-4e9a-818c-159e31e2221a");

            migrationBuilder.DropColumn(
                name: "IsReminded",
                table: "task");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "354801ed-ac7c-4407-a3d4-57c48220af63", null, "Admin", "ADMIN" },
                    { "69542378-87d9-4059-8b8f-4276ac5deb22", null, "User", "USER" }
                });
        }
    }
}
