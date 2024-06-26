using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class addUserNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "Risk");

            migrationBuilder.AddColumn<string>(
                name: "nome_usuario",
                table: "Risk",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome_usuario",
                table: "Risk");

            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "Risk",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
