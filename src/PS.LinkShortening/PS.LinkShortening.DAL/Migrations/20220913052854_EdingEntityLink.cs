using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.LinkShortening.DAL.Migrations
{
    public partial class EdingEntityLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortURL",
                table: "Links",
                newName: "Metadata");

            migrationBuilder.AlterColumn<string>(
                name: "LongURL",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "Links",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Links",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Links",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuthTokenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanGet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTokenItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_Key",
                table: "Links",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokenItems_AuthToken",
                table: "AuthTokenItems",
                column: "AuthToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthTokenItems");

            migrationBuilder.DropIndex(
                name: "IX_Links_Key",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Expires",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Metadata",
                table: "Links",
                newName: "ShortURL");

            migrationBuilder.AlterColumn<string>(
                name: "LongURL",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
