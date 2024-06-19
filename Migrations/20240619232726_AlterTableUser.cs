using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "sessaoValida",
                table: "User",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sessaoValida",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "token",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
