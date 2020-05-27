using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class updateafterDelKPIIdinProgramme : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
