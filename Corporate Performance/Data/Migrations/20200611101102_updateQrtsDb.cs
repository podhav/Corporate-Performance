using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class updateQrtsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnualActual",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualDeviation",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualTarget",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt2Deviation",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt3Deviation",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt4Deviation",
                table: "Performance",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualActual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "AnnualDeviation",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "AnnualTarget",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt2Deviation",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt3Deviation",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt4Deviation",
                table: "Performance");
        }
    }
}
