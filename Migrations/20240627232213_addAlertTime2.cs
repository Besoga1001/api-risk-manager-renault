using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class addAlertTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Impacto_Resudual",
                table: "Solution",
                newName: "Impacto_Residual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Impacto_Residual",
                table: "Solution",
                newName: "Impacto_Resudual");
        }
    }
}
