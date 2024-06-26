using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: true);

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
    }
}
