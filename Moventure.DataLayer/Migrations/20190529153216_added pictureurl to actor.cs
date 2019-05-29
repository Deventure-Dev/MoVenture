using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moventure.DataLayer.Migrations
{
    public partial class addedpictureurltoactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActorIntermediate");

            migrationBuilder.DropTable(
                name: "MoviePlaylistIntermediate");

            migrationBuilder.DropTable(
                name: "MovieTagIntermediate");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Actors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieActorAssignment",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActorAssignment", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActorAssignment_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActorAssignment_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistMovieAssignment",
                columns: table => new
                {
                    PlaylistId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistMovieAssignment", x => new { x.PlaylistId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_PlaylistMovieAssignment_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistMovieAssignment_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagsMovieAssignment",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsMovieAssignment", x => new { x.TagId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_TagsMovieAssignment_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsMovieAssignment_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActorAssignment_MovieId",
                table: "MovieActorAssignment",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistMovieAssignment_MovieId",
                table: "PlaylistMovieAssignment",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsMovieAssignment_MovieId",
                table: "TagsMovieAssignment",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActorAssignment");

            migrationBuilder.DropTable(
                name: "PlaylistMovieAssignment");

            migrationBuilder.DropTable(
                name: "TagsMovieAssignment");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Actors");

            migrationBuilder.CreateTable(
                name: "MovieActorIntermediate",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActorIntermediate", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActorIntermediate_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActorIntermediate_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePlaylistIntermediate",
                columns: table => new
                {
                    PlaylistId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlaylistIntermediate", x => new { x.PlaylistId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MoviePlaylistIntermediate_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePlaylistIntermediate_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTagIntermediate",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTagIntermediate", x => new { x.TagId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieTagIntermediate_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTagIntermediate_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActorIntermediate_MovieId",
                table: "MovieActorIntermediate",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlaylistIntermediate_MovieId",
                table: "MoviePlaylistIntermediate",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTagIntermediate_MovieId",
                table: "MovieTagIntermediate",
                column: "MovieId");
        }
    }
}
