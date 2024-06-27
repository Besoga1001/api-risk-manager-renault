using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_renault.Migrations
{
    /// <inheritdoc />
    public partial class addAlertTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlerta",
                table: "Solution",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlerta",
                table: "Solution");
        }
    }
}
