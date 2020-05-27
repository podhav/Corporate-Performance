using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class UpdateModelProgrammeandKPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programme_KPI_KPIId",
                table: "Programme");

            migrationBuilder.DropIndex(
                name: "IX_Programme_KPIId",
                table: "Programme");

            migrationBuilder.DropColumn(
                name: "KPIId",
                table: "Programme");

            migrationBuilder.AddColumn<int>(
                name: "KPIId",
                table: "KPI",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "KPI",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KPI_ProgrammeId",
                table: "KPI",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI",
                column: "ProgrammeId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_KPI_ProgrammeId",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "KPIId",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "KPI");

            migrationBuilder.AddColumn<int>(
                name: "KPIId",
                table: "Programme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Programme_KPIId",
                table: "Programme",
                column: "KPIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programme_KPI_KPIId",
                table: "Programme",
                column: "KPIId",
                principalTable: "KPI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
