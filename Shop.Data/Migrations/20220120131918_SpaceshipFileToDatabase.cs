using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class SpaceshipFileToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImageTitle = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    SpaceshipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");
        }
    }
}
