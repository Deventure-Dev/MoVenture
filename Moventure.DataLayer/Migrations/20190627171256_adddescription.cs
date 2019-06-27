using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moventure.DataLayer.Migrations
{
    public partial class adddescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");
        }
    }
}
