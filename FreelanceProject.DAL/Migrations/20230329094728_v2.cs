using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "CaseID", "HasConditions", "ImageUrl", "QuestionQ_ID", "Title" },
                values: new object[,]
                {
                    { 1, false, "heart.jpg", null, "ازمة قلبية" },
                    { 2, false, "faints.png", null, "الاغماء" },
                    { 3, false, "bites.jpg", null, "العضات" },
                    { 4, false, "antsBite.png", null, "اللدغات" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseID",
                keyValue: 4);
        }
    }
}
