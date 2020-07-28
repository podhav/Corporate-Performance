﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate_Performance.Data.Migrations
{
    public partial class changeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Files_FilesId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_FilesId",
                table: "Performance");

            migrationBuilder.AlterColumn<int>(
                name: "FilesId",
                table: "Performance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FilesId",
                table: "Performance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Performance_FilesId",
                table: "Performance",
                column: "FilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Files_FilesId",
                table: "Performance",
                column: "FilesId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
