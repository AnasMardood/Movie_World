using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCity98.Migrations
{
    /// <inheritdoc />
    public partial class MoviesActorsAndProducers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieProducer_Movies_MoviesMovieId",
                table: "MovieProducer");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieProducer_Producers_ProducersProducerId",
                table: "MovieProducer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieProducer",
                table: "MovieProducer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.RenameTable(
                name: "MovieProducer",
                newName: "MoviesProducers");

            migrationBuilder.RenameTable(
                name: "ActorMovie",
                newName: "MoviesActors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieProducer_ProducersProducerId",
                table: "MoviesProducers",
                newName: "IX_MoviesProducers_ProducersProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "MoviesActors",
                newName: "IX_MoviesActors_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesProducers",
                table: "MoviesProducers",
                columns: new[] { "MoviesMovieId", "ProducersProducerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                columns: new[] { "ActorsActorId", "MoviesMovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Actors_ActorsActorId",
                table: "MoviesActors",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MoviesMovieId",
                table: "MoviesActors",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesProducers_Movies_MoviesMovieId",
                table: "MoviesProducers",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesProducers_Producers_ProducersProducerId",
                table: "MoviesProducers",
                column: "ProducersProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Actors_ActorsActorId",
                table: "MoviesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MoviesMovieId",
                table: "MoviesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesProducers_Movies_MoviesMovieId",
                table: "MoviesProducers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesProducers_Producers_ProducersProducerId",
                table: "MoviesProducers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesProducers",
                table: "MoviesProducers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.RenameTable(
                name: "MoviesProducers",
                newName: "MovieProducer");

            migrationBuilder.RenameTable(
                name: "MoviesActors",
                newName: "ActorMovie");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesProducers_ProducersProducerId",
                table: "MovieProducer",
                newName: "IX_MovieProducer_ProducersProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActors_MoviesMovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieProducer",
                table: "MovieProducer",
                columns: new[] { "MoviesMovieId", "ProducersProducerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                columns: new[] { "ActorsActorId", "MoviesMovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieProducer_Movies_MoviesMovieId",
                table: "MovieProducer",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieProducer_Producers_ProducersProducerId",
                table: "MovieProducer",
                column: "ProducersProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
