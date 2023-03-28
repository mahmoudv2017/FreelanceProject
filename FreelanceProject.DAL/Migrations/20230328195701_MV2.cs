using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChoiceID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionQ_ID",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_QuestionQ_ID",
                table: "Cases",
                column: "QuestionQ_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Questions_QuestionQ_ID",
                table: "Cases",
                column: "QuestionQ_ID",
                principalTable: "Questions",
                principalColumn: "Q_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Questions_QuestionQ_ID",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_QuestionQ_ID",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ChoiceID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionQ_ID",
                table: "Cases");
        }
    }
}
