using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations.Store
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposers_Composer_ComposerId",
                table: "SheetMusicComposers");

            migrationBuilder.DropTable(
                name: "CountryZipCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composer",
                table: "Composer");

            migrationBuilder.RenameTable(
                name: "Composer",
                newName: "Composers");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Products",
                newName: "SheetMusic_ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Products",
                newName: "SheetMusic_PublisherId");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Products",
                newName: "SheetMusic_Length");

            migrationBuilder.RenameColumn(
                name: "IsbnId",
                table: "Products",
                newName: "SheetMusic_IsbnId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "SheetMusic_Description");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Products",
                newName: "DigitalSheetMusic_Size");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PublisherId",
                table: "Products",
                newName: "IX_Products_SheetMusic_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IsbnId",
                table: "Products",
                newName: "IX_Products_SheetMusic_IsbnId");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ZipCodes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsbnId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteBook",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composers",
                table: "Composers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_CountryId",
                table: "ZipCodes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsbnId",
                table: "Products",
                column: "IsbnId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PublisherId",
                table: "Products",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products",
                column: "IsbnId",
                principalTable: "Isbns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Isbns_SheetMusic_IsbnId",
                table: "Products",
                column: "SheetMusic_IsbnId",
                principalTable: "Isbns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_SheetMusic_PublisherId",
                table: "Products",
                column: "SheetMusic_PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposers_Composers_ComposerId",
                table: "SheetMusicComposers",
                column: "ComposerId",
                principalTable: "Composers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCodes_Countries_CountryId",
                table: "ZipCodes",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Isbns_SheetMusic_IsbnId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_SheetMusic_PublisherId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposers_Composers_ComposerId",
                table: "SheetMusicComposers");

            migrationBuilder.DropForeignKey(
                name: "FK_ZipCodes_Countries_CountryId",
                table: "ZipCodes");

            migrationBuilder.DropIndex(
                name: "IX_ZipCodes_CountryId",
                table: "ZipCodes");

            migrationBuilder.DropIndex(
                name: "IX_Products_IsbnId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PublisherId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composers",
                table: "Composers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ZipCodes");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsbnId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FavoriteBook",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Composers",
                newName: "Composer");

            migrationBuilder.RenameColumn(
                name: "SheetMusic_ReleaseDate",
                table: "Products",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "SheetMusic_PublisherId",
                table: "Products",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "SheetMusic_Length",
                table: "Products",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "SheetMusic_IsbnId",
                table: "Products",
                newName: "IsbnId");

            migrationBuilder.RenameColumn(
                name: "SheetMusic_Description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DigitalSheetMusic_Size",
                table: "Products",
                newName: "Size");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SheetMusic_PublisherId",
                table: "Products",
                newName: "IX_Products_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SheetMusic_IsbnId",
                table: "Products",
                newName: "IX_Products_IsbnId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composer",
                table: "Composer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CountryZipCodes",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    ZipCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryZipCodes", x => new { x.CountryId, x.ZipCodeId });
                    table.ForeignKey(
                        name: "FK_CountryZipCodes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryZipCodes_ZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "ZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryZipCodes_ZipCodeId",
                table: "CountryZipCodes",
                column: "ZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Isbns_IsbnId",
                table: "Products",
                column: "IsbnId",
                principalTable: "Isbns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposers_Composer_ComposerId",
                table: "SheetMusicComposers",
                column: "ComposerId",
                principalTable: "Composer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
