using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class filestwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Files_FilesId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_FilesId",
                table: "Performance");
        }
    }
}
