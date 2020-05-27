using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class updateKPIDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "KPIId",
                table: "KPI");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "KPI",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI",
                column: "ProgrammeId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPI_Programme_ProgrammeId",
                table: "KPI");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "KPI",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "KPIId",
                table: "KPI",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
