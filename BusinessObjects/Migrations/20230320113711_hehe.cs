using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class hehe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_PaperQuestions_PaperQuestionId",
                table: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "PaperQuestionId",
                table: "UserAnswers",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_PaperQuestionId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "UserAnswers",
                newName: "PaperQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_PaperQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_PaperQuestions_PaperQuestionId",
                table: "UserAnswers",
                column: "PaperQuestionId",
                principalTable: "PaperQuestions",
                principalColumn: "PaperQuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
