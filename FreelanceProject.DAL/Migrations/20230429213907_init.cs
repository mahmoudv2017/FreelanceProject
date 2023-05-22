using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Ins_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Ins_Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasImage = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Ins_ID);
                });

            migrationBuilder.CreateTable(
                name: "Question_Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Q_ID = table.Column<int>(type: "int", nullable: false),
                    Case_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Q_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    ChoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Q_ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Emergency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logntitue = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8,6)", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Emergency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Emergency_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasConditions = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionQ_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseID);
                    table.ForeignKey(
                        name: "FK_Cases_Questions_QuestionQ_ID",
                        column: x => x.QuestionQ_ID,
                        principalTable: "Questions",
                        principalColumn: "Q_ID");
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Ch_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsImage = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Ch_ID);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_Q_Id",
                        column: x => x.Q_Id,
                        principalTable: "Questions",
                        principalColumn: "Q_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emergencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    SubCaseID = table.Column<int>(type: "int", nullable: false),
                    SubCaseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q_Id = table.Column<int>(type: "int", nullable: false),
                    Q_Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CH_Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CH_Id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emergencies_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyV2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCaseTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_EmergencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyV2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmergencyV2_User_Emergency_User_EmergencyId",
                        column: x => x.User_EmergencyId,
                        principalTable: "User_Emergency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCases",
                columns: table => new
                {
                    SubCaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCases", x => x.SubCaseID);
                    table.ForeignKey(
                        name: "FK_SubCases_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "CaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyV2Questions_Answers",
                columns: table => new
                {
                    EmergenciesID = table.Column<int>(type: "int", nullable: false),
                    Questions_AnswersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyV2Questions_Answers", x => new { x.EmergenciesID, x.Questions_AnswersId });
                    table.ForeignKey(
                        name: "FK_EmergencyV2Questions_Answers_EmergencyV2_EmergenciesID",
                        column: x => x.EmergenciesID,
                        principalTable: "EmergencyV2",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyV2Questions_Answers_Questions_Answers_Questions_AnswersId",
                        column: x => x.Questions_AnswersId,
                        principalTable: "Questions_Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCase_ID = table.Column<int>(type: "int", nullable: false),
                    C_Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.C_ID);
                    table.ForeignKey(
                        name: "FK_Conditions_SubCases_SubCase_ID",
                        column: x => x.SubCase_ID,
                        principalTable: "SubCases",
                        principalColumn: "SubCaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCases_Instructions",
                columns: table => new
                {
                    Instructions_ID = table.Column<int>(type: "int", nullable: false),
                    Subcase_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCases_Instructions", x => new { x.Subcase_ID, x.Instructions_ID });
                    table.ForeignKey(
                        name: "FK_SubCases_Instructions_Instructions_Instructions_ID",
                        column: x => x.Instructions_ID,
                        principalTable: "Instructions",
                        principalColumn: "Ins_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCases_Instructions_SubCases_Subcase_ID",
                        column: x => x.Subcase_ID,
                        principalTable: "SubCases",
                        principalColumn: "SubCaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCasesYoutubeLinks",
                columns: table => new
                {
                    SubCaseID = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCasesYoutubeLinks", x => new { x.SubCaseID, x.Link });
                    table.ForeignKey(
                        name: "FK_SubCasesYoutubeLinks_SubCases_SubCaseID",
                        column: x => x.SubCaseID,
                        principalTable: "SubCases",
                        principalColumn: "SubCaseID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_QuestionQ_ID",
                table: "Cases",
                column: "QuestionQ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_Q_Id",
                table: "Choices",
                column: "Q_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_SubCase_ID",
                table: "Conditions",
                column: "SubCase_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_UserId",
                table: "Emergencies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyV2_User_EmergencyId",
                table: "EmergencyV2",
                column: "User_EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyV2Questions_Answers_Questions_AnswersId",
                table: "EmergencyV2Questions_Answers",
                column: "Questions_AnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCases_CaseID",
                table: "SubCases",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCases_Instructions_Instructions_ID",
                table: "SubCases_Instructions",
                column: "Instructions_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Emergency_ApplicationUserID",
                table: "User_Emergency",
                column: "ApplicationUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Emergencies");

            migrationBuilder.DropTable(
                name: "EmergencyV2Questions_Answers");

            migrationBuilder.DropTable(
                name: "Question_Cases");

            migrationBuilder.DropTable(
                name: "SubCases_Instructions");

            migrationBuilder.DropTable(
                name: "SubCasesYoutubeLinks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EmergencyV2");

            migrationBuilder.DropTable(
                name: "Questions_Answers");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "SubCases");

            migrationBuilder.DropTable(
                name: "User_Emergency");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
