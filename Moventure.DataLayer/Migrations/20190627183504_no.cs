using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moventure.DataLayer.Migrations
{
    public partial class no : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Playlists",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Playlists",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
