using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exam.Migrations
{
    public partial class updateExam2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Exams",
                newName: "DateTo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Exams",
                newName: "Date");
        }
    }
}
