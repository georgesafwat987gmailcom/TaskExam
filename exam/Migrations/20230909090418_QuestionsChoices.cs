using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exam.Migrations
{
    public partial class QuestionsChoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamsId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ExamsId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionsChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCoreect = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsChoices_QuestionId",
                table: "QuestionsChoices",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamsId",
                table: "Questions",
                column: "ExamsId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamsId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionsChoices");

            migrationBuilder.AlterColumn<int>(
                name: "ExamsId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamsId",
                table: "Questions",
                column: "ExamsId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}
