using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class urlLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ac634af-f4dd-4b16-9f9f-50277669bed7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbda466b-1b4f-44ff-9069-305fead0723a");

            migrationBuilder.AlterColumn<string>(
                name: "profileUrl",
                table: "memberprofile",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1da030d5-e2c3-4d83-80a0-f5ca4fafaf49", null, "Admin", "ADMIN" },
                    { "637fb914-e170-41cf-8f38-5d4578a2de67", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da030d5-e2c3-4d83-80a0-f5ca4fafaf49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637fb914-e170-41cf-8f38-5d4578a2de67");

            migrationBuilder.AlterColumn<string>(
                name: "profileUrl",
                table: "memberprofile",
                type: "varchar(25)",
                maxLength: 25,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ac634af-f4dd-4b16-9f9f-50277669bed7", null, "Admin", "ADMIN" },
                    { "cbda466b-1b4f-44ff-9069-305fead0723a", null, "User", "USER" }
                });
        }
    }
}
