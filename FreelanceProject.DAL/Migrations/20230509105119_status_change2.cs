using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class status_change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Ins_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 16);

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

            migrationBuilder.DeleteData(
                table: "SubCases",
                keyColumn: "SubCaseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseID",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Emergency_Status_Change",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_EmergencyID = table.Column<int>(type: "int", nullable: false),
                    StatusPart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergency_Status_Change", x => new { x.UserID, x.User_EmergencyID, x.StatusPart });
                    table.ForeignKey(
                        name: "FK_Emergency_Status_Change_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emergency_Status_Change_User_Emergency_User_EmergencyID",
                        column: x => x.User_EmergencyID,
                        principalTable: "User_Emergency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emergency_Status_Change_User_EmergencyID",
                table: "Emergency_Status_Change",
                column: "User_EmergencyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emergency_Status_Change");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

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
                table: "SubCases",
                columns: new[] { "SubCaseID", "CaseID", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع" },
                    { 2, 1, "النوبات القلبية الصامتة" },
                    { 3, 1, "ST احتشاء عضلة القلب غير المرتبطة بمقطع" },
                    { 4, 2, "(إغماء وعائي مبهمي (إغماء قلبي وعصبي" },
                    { 5, 2, "إغماء الظرفية" },
                    { 6, 2, "(الإغماء الوضعي (انخفاض ضغط الدم الوضعي" },
                    { 7, 2, "إغماء عصبي" },
                    { 8, 2, "(POTS) متلازمة تسرع القلب الانتصابي الوضعي " },
                    { 9, 3, "عضات سامة" },
                    { 10, 3, "عضات غير سامة" },
                    { 11, 4, "قرصة القراد" },
                    { 12, 4, "قرصة العنكبوت" },
                    { 13, 4, "قرصة البعوض" },
                    { 14, 4, "قرصات بق الفراش" },
                    { 15, 4, "قرصات قمل الرأس" },
                    { 16, 4, "لدغات البراغيث" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "C_ID", "C_Body", "SubCase_ID" },
                values: new object[,]
                {
                    { 1, "انزعاج أو شعور بالألم في منطقة الصدر", 1 },
                    { 2, "الألم في الجزء العلوي من الجسم", 1 },
                    { 3, "  ألم المعدة و ضيق تنفس ", 1 }
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
    }
}
