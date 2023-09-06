using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserInterface.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationTokenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Authenticated",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationToken",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authenticated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthenticationToken",
                table: "Users");
        }
    }
}
