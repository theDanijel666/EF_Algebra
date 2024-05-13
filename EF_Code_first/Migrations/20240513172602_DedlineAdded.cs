using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Code_first.Migrations
{
    /// <inheritdoc />
    public partial class DedlineAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dedline",
                table: "ToDoModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dedline",
                table: "ToDoModel");
        }
    }
}
