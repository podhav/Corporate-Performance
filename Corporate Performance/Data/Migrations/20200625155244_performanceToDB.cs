using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class performanceToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerformanceId",
                table: "Files",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
