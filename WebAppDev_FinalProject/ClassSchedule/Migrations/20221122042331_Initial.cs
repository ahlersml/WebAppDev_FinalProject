using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    DateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    RenterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.RenterId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    genre = table.Column<string>(maxLength: 200, nullable: false),
                    RenterId = table.Column<int>(nullable: false),
                    DateId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genres_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "DateId", "Name" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "02/02/2022" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Anne", "Sullivan" },
                    { 2, "Maria", "Montessori" },
                    { 3, "Martin Luther", "King" },
                    { 4, "", "Aristotle" },
                    { 5, "Jaime", "Escalante" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Date", "DateId", "RenterId", "Title", "genre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Avengers Endgame", "Action" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "A Walk to Remember", "Drama" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "A Silent Voice", "Anime" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "Breaking Bad Season 1", "Tv/Action" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Halloween", "Horror" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, "Talladega Nights", "Comedy" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Scarface", "Action" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Titanic", "Drama" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, "Good Will Hunting", "Drama" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "50 First Dates", "Romantic Comedy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_DateId",
                table: "Genres",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_RenterId",
                table: "Genres",
                column: "RenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Renters");
        }
    }
}
