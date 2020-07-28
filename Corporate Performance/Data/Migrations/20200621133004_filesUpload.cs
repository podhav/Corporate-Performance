using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class filesUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "FilesId",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    FileType = table.Column<string>(maxLength: 100, nullable: true),
                    DataFiles = table.Column<byte[]>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performance_FilesId",
                table: "Performance",
                column: "FilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Files_FilesId",
                table: "Performance",
                column: "FilesId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Files_FilesId",
                table: "Performance");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Performance_FilesId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "FilesId",
                table: "Performance");

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "Performance",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
