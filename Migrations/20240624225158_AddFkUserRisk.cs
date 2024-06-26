using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class AddFkUserRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "User",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "Risk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Risk_id_usuario",
                table: "Risk",
                column: "id_usuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_User_id_usuario",
                table: "Risk",
                column: "id_usuario",
                principalTable: "User",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_User_id_usuario",
                table: "Risk");

            migrationBuilder.DropIndex(
                name: "IX_Risk_id_usuario",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "Risk");
        }
    }
}
