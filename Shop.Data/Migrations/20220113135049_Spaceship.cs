using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class Spaceship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    EnginePower = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    LaunchDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_ProductId",
                table: "ExistingFilePath",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath");

            migrationBuilder.DropTable(
                name: "Spaceship");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_ProductId",
                table: "ExistingFilePath");
        }
    }
}
