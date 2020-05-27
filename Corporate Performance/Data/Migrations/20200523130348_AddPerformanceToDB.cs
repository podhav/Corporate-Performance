using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class AddPerformanceToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodId = table.Column<int>(nullable: false),
                    KPAId = table.Column<int>(nullable: false),
                    KPIId = table.Column<int>(nullable: false),
                    QrtTarget = table.Column<int>(nullable: false),
                    QrtActual = table.Column<int>(nullable: false),
                    QrtDeviation = table.Column<int>(nullable: false),
                    AnnualTarget = table.Column<int>(nullable: false),
                    AnnualActual = table.Column<int>(nullable: false),
                    AnnualDeviation = table.Column<int>(nullable: false),
                    CorrectiveAction = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performance_KPA_KPAId",
                        column: x => x.KPAId,
                        principalTable: "KPA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_KPI_KPIId",
                        column: x => x.KPIId,
                        principalTable: "KPI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performance_KPAId",
                table: "Performance",
                column: "KPAId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_KPIId",
                table: "Performance",
                column: "KPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_PeriodId",
                table: "Performance",
                column: "PeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performance");
        }
    }
}
