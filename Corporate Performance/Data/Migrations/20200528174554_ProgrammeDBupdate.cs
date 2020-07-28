using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class ProgrammeDBupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Programme_ProgramId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_ProgramId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "Performance",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ProgramId",
                table: "Performance",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Programme_ProgramId",
                table: "Performance",
                column: "ProgramId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
