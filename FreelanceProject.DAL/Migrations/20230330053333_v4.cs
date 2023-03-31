using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "C_ID", "C_Body", "SubCase_ID" },
                values: new object[,]
                {
                    { 1, "انزعاج أو شعور بالألم في منطقة الصدر", 1 },
                    { 2, "الألم في الجزء العلوي من الجسم", 1 },
                    { 3, "  ألم المعدة و ضيق تنفس ", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "C_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "C_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "C_ID",
                keyValue: 3);
        }
    }
}
