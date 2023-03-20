using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class haha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAnswerText",
                table: "UserAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "UserAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Selected",
                table: "UserAnswers");

            migrationBuilder.AddColumn<string>(
                name: "UserAnswerText",
                table: "UserAnswers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
