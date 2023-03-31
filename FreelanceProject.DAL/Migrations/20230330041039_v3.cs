using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubCases",
                columns: new[] { "SubCaseID", "CaseID", "Title" },
                values: new object[,]
                {
                    { 1, 1, " ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع" },
                    { 2, 1, "النوبات القلبية الصامتة" },
                    { 3, 1, " ST احتشاء عضلة القلب غير المرتبطة بمقطع" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 3);
        }
    }
}
