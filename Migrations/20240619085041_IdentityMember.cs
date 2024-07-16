using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "member",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_member_AppUserId",
                table: "member",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_AspNetUsers_AppUserId",
                table: "member",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_AspNetUsers_AppUserId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_AppUserId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "member");
        }
    }
}
