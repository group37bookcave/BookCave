using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class AuthenticationInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Products_BookId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Formats_FormatId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposer_Composer_ComposerId",
                table: "SheetMusicComposer");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposer_Products_SheetMusicId",
                table: "SheetMusicComposer");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SheetMusicComposer",
                table: "SheetMusicComposer");

            migrationBuilder.DropIndex(
                name: "IX_Products_FormatId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "SheetMusicComposer",
                newName: "SheetMusicComposers");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BookAuthors");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "SecurityStamp");

            migrationBuilder.RenameIndex(
                name: "IX_SheetMusicComposer_ComposerId",
                table: "SheetMusicComposers",
                newName: "IX_SheetMusicComposers_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthors",
                newName: "IX_BookAuthors_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CustomerOrders",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CustomerAddresses",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SheetMusicComposers",
                table: "SheetMusicComposers",
                columns: new[] { "SheetMusicId", "ComposerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Products_BookId",
                table: "BookAuthors",
                column: "BookId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposers_Composer_ComposerId",
                table: "SheetMusicComposers",
                column: "ComposerId",
                principalTable: "Composer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposers_Products_SheetMusicId",
                table: "SheetMusicComposers",
                column: "SheetMusicId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Products_BookId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposers_Composer_ComposerId",
                table: "SheetMusicComposers");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMusicComposers_Products_SheetMusicId",
                table: "SheetMusicComposers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SheetMusicComposers",
                table: "SheetMusicComposers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "SheetMusicComposers",
                newName: "SheetMusicComposer");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_SheetMusicComposers_ComposerId",
                table: "SheetMusicComposer",
                newName: "IX_SheetMusicComposer_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerOrders",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerAddresses",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SheetMusicComposer",
                table: "SheetMusicComposer",
                columns: new[] { "SheetMusicId", "ComposerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FormatId",
                table: "Products",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Products_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Formats_FormatId",
                table: "Products",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposer_Composer_ComposerId",
                table: "SheetMusicComposer",
                column: "ComposerId",
                principalTable: "Composer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMusicComposer_Products_SheetMusicId",
                table: "SheetMusicComposer",
                column: "SheetMusicId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
