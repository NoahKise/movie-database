using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.Migrations
{
    public partial class AddMpaRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MpaRating",
                table: "Films",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_FilmId",
                table: "Actors",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Films_FilmId",
                table: "Actors",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Films_FilmId",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_FilmId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MpaRating",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Actors");
        }
    }
}
