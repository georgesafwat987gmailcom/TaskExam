using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exam.Migrations
{
    public partial class updateExamQustion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Degree",
                table: "Questions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Exams",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));






        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Exams");



        }
    }
}
