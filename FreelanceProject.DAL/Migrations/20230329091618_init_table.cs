using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_SubCases_CaseID",
                table: "SubCases",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCases_Instructions_Instructions_ID",
                table: "SubCases_Instructions",
                column: "Instructions_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Question_Cases");

            migrationBuilder.DropTable(
                name: "SubCases_Instructions");

            migrationBuilder.DropTable(
                name: "SubCasesYoutubeLinks");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "SubCases");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
