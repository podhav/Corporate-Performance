using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class AddPerformanceQrtsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualActual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "AnnualTarget",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "QrtActual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "QrtTarget",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "Qrt1Actual",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt1Target",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt2Actual",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt2Target",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt3Actual",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt3Target",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt4Actual",
                table: "Performance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qrt4Target",
                table: "Performance",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qrt1Actual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt1Target",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt2Actual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt2Target",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt3Actual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt3Target",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt4Actual",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Qrt4Target",
                table: "Performance");

            migrationBuilder.AddColumn<int>(
                name: "AnnualActual",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualTarget",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QrtActual",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QrtTarget",
                table: "Performance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
