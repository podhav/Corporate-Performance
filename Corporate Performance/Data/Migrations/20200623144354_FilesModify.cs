using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class FilesModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Performance_PerformanceId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_PerformanceId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "Performance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "PerformanceId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_PerformanceId",
                table: "Files",
                column: "PerformanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Performance_PerformanceId",
                table: "Files",
                column: "PerformanceId",
                principalTable: "Performance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
