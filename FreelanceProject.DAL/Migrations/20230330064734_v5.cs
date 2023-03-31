using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Ins_ID", "HasImage", "ImageURL", "Ins_Body", "Order", "Severity" },
                values: new object[,]
                {
                    { 1, false, null, "اتصل على  رقم الطوارئ في بلدك", 1, 2 },
                    { 2, false, null, "امضغ الأسبرين ثم ابلعه أثناء انتظارك المساعدة الطارئة.", 2, 0 },
                    { 3, false, null, "تناول نيتروغلسرين، إذا وُصف لك", 3, 2 },
                    { 4, false, null, " ابدأ الإنعاش القلبي الرئوي إذا كان الشخص فاقدًا للوعي.", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "SubCases_Instructions",
                columns: new[] { "Instructions_ID", "Subcase_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Ins_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCases_Instructions",
                keyColumns: new[] { "Instructions_ID", "Subcase_ID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SubCases_Instructions",
                keyColumns: new[] { "Instructions_ID", "Subcase_ID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SubCases_Instructions",
                keyColumns: new[] { "Instructions_ID", "Subcase_ID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Ins_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Ins_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Ins_ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
