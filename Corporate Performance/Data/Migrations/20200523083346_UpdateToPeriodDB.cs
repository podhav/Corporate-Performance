using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class UpdateToPeriodDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quarter",
                table: "Period",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quarter",
                table: "Period");
        }
    }
}
