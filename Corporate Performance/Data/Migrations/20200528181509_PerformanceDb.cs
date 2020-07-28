using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class PerformanceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Programme_ProgrammeId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_ProgrammeId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "Performance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ProgrammeId",
                table: "Performance",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Programme_ProgrammeId",
                table: "Performance",
                column: "ProgrammeId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
