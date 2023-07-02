using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameIntermediateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModelGameModel_Collections_CollectionsId",
                table: "CollectionModelGameModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModelGameModel_Games_GamesId",
                table: "CollectionModelGameModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsoleModelGameModel_Consoles_ConsolesId",
                table: "ConsoleModelGameModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsoleModelGameModel_Games_GamesId",
                table: "ConsoleModelGameModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GameModelGenreModel_Games_GamesId",
                table: "GameModelGenreModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GameModelGenreModel_Genres_GenresId",
                table: "GameModelGenreModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameModelGenreModel",
                table: "GameModelGenreModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsoleModelGameModel",
                table: "ConsoleModelGameModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionModelGameModel",
                table: "CollectionModelGameModel");

            migrationBuilder.RenameTable(
                name: "GameModelGenreModel",
                newName: "GenresGames");

            migrationBuilder.RenameTable(
                name: "ConsoleModelGameModel",
                newName: "ConsolesGames");

            migrationBuilder.RenameTable(
                name: "CollectionModelGameModel",
                newName: "CollectionsGames");

            migrationBuilder.RenameIndex(
                name: "IX_GameModelGenreModel_GenresId",
                table: "GenresGames",
                newName: "IX_GenresGames_GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsoleModelGameModel_GamesId",
                table: "ConsolesGames",
                newName: "IX_ConsolesGames_GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionModelGameModel_GamesId",
                table: "CollectionsGames",
                newName: "IX_CollectionsGames_GamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenresGames",
                table: "GenresGames",
                columns: new[] { "GamesId", "GenresId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsolesGames",
                table: "ConsolesGames",
                columns: new[] { "ConsolesId", "GamesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionsGames",
                table: "CollectionsGames",
                columns: new[] { "CollectionsId", "GamesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionsGames_Collections_CollectionsId",
                table: "CollectionsGames",
                column: "CollectionsId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionsGames_Games_GamesId",
                table: "CollectionsGames",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolesGames_Consoles_ConsolesId",
                table: "ConsolesGames",
                column: "ConsolesId",
                principalTable: "Consoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolesGames_Games_GamesId",
                table: "ConsolesGames",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenresGames_Games_GamesId",
                table: "GenresGames",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenresGames_Genres_GenresId",
                table: "GenresGames",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionsGames_Collections_CollectionsId",
                table: "CollectionsGames");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionsGames_Games_GamesId",
                table: "CollectionsGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolesGames_Consoles_ConsolesId",
                table: "ConsolesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolesGames_Games_GamesId",
                table: "ConsolesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GenresGames_Games_GamesId",
                table: "GenresGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GenresGames_Genres_GenresId",
                table: "GenresGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenresGames",
                table: "GenresGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsolesGames",
                table: "ConsolesGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionsGames",
                table: "CollectionsGames");

            migrationBuilder.RenameTable(
                name: "GenresGames",
                newName: "GameModelGenreModel");

            migrationBuilder.RenameTable(
                name: "ConsolesGames",
                newName: "ConsoleModelGameModel");

            migrationBuilder.RenameTable(
                name: "CollectionsGames",
                newName: "CollectionModelGameModel");

            migrationBuilder.RenameIndex(
                name: "IX_GenresGames_GenresId",
                table: "GameModelGenreModel",
                newName: "IX_GameModelGenreModel_GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsolesGames_GamesId",
                table: "ConsoleModelGameModel",
                newName: "IX_ConsoleModelGameModel_GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionsGames_GamesId",
                table: "CollectionModelGameModel",
                newName: "IX_CollectionModelGameModel_GamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameModelGenreModel",
                table: "GameModelGenreModel",
                columns: new[] { "GamesId", "GenresId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsoleModelGameModel",
                table: "ConsoleModelGameModel",
                columns: new[] { "ConsolesId", "GamesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionModelGameModel",
                table: "CollectionModelGameModel",
                columns: new[] { "CollectionsId", "GamesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModelGameModel_Collections_CollectionsId",
                table: "CollectionModelGameModel",
                column: "CollectionsId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModelGameModel_Games_GamesId",
                table: "CollectionModelGameModel",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsoleModelGameModel_Consoles_ConsolesId",
                table: "ConsoleModelGameModel",
                column: "ConsolesId",
                principalTable: "Consoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsoleModelGameModel_Games_GamesId",
                table: "ConsoleModelGameModel",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameModelGenreModel_Games_GamesId",
                table: "GameModelGenreModel",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameModelGenreModel_Genres_GenresId",
                table: "GameModelGenreModel",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
