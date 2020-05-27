using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class AddFiscalandChangestoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_KPI_ProgrammeId",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "FiscalYear",
                table: "Period");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "KPI");

            migrationBuilder.AddColumn<int>(
                name: "KPIId",
                table: "Programme",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalId",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fiscal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYear = table.Column<int>(nullable: false),
                    YearStartDate = table.Column<DateTime>(nullable: false),
                    YearEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiscal", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programme_KPIId",
                table: "Programme",
                column: "KPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_FiscalId",
                table: "Performance",
                column: "FiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ProgramId",
                table: "Performance",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Fiscal_FiscalId",
                table: "Performance",
                column: "FiscalId",
                principalTable: "Fiscal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Programme_ProgramId",
                table: "Performance",
                column: "ProgramId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programme_KPI_KPIId",
                table: "Programme",
                column: "KPIId",
                principalTable: "KPI",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Fiscal_FiscalId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Programme_ProgramId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Programme_KPI_KPIId",
                table: "Programme");

            migrationBuilder.DropTable(
                name: "Fiscal");

            migrationBuilder.DropIndex(
                name: "IX_Programme_KPIId",
                table: "Programme");

            migrationBuilder.DropIndex(
                name: "IX_Performance_FiscalId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_ProgramId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "KPIId",
                table: "Programme");

            migrationBuilder.DropColumn(
                name: "FiscalId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "FiscalYear",
                table: "Period",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "KPI",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.NoAction);
        }
    }
}
