using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class inheritance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsbnId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsbnId",
                table: "Products",
                column: "IsbnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products",
                column: "IsbnId",
                principalTable: "Isbns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IsbnId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsbnId",
                table: "Products");
        }
    }
}
