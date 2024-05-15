using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Migracije.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocjena = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "ID", "Bio", "Name", "Ocjena" },
                values: new object[,]
                {
                    { 1, "Hrvatska književnica poznata po dječijim pričama", "Ivana Brlić-Mažuranić", 4.0 },
                    { 2, "Pisac", "Miroslav Krleža", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "ID", "AuthorId", "Description", "Genre", "ReleaseDate", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, "", "Bajka", new DateTime(2024, 5, 15, 20, 53, 19, 238, DateTimeKind.Local).AddTicks(3984), 10, "Šegrt Hlapić" },
                    { 2, 1, "", "Bajka", new DateTime(2024, 5, 15, 20, 53, 19, 238, DateTimeKind.Local).AddTicks(4028), 14, "Šegrt Hlapić 2" },
                    { 3, 1, "", "Bajka", new DateTime(2024, 5, 15, 20, 53, 19, 238, DateTimeKind.Local).AddTicks(4030), 26, "Šegrt Hlapić 3" },
                    { 4, 2, "", "Drama", new DateTime(2024, 5, 15, 20, 53, 19, 238, DateTimeKind.Local).AddTicks(4032), 4, "Zlatarevo Zlato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
