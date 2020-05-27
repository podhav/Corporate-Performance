using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes");

            migrationBuilder.RenameTable(
                name: "Programmes",
                newName: "Programme");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programme",
                table: "Programme",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programme",
                table: "Programme");

            migrationBuilder.RenameTable(
                name: "Programme",
                newName: "Programmes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes",
                column: "Id");
        }
    }
}
