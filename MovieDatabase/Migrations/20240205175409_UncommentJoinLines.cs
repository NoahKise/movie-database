using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.Migrations
{
    public partial class UncommentJoinLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActorFilms_ActorId",
                table: "ActorFilms",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilms_FilmId",
                table: "ActorFilms",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilms_Actors_ActorId",
                table: "ActorFilms",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilms_Films_FilmId",
                table: "ActorFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilms_Actors_ActorId",
                table: "ActorFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilms_Films_FilmId",
                table: "ActorFilms");

            migrationBuilder.DropIndex(
                name: "IX_ActorFilms_ActorId",
                table: "ActorFilms");

            migrationBuilder.DropIndex(
                name: "IX_ActorFilms_FilmId",
                table: "ActorFilms");
        }
    }
}
