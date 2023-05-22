using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class status_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergency_Status_Change_AspNetUsers_UserID",
                table: "Emergency_Status_Change");

            migrationBuilder.DropForeignKey(
                name: "FK_Emergency_Status_Change_User_Emergency_User_EmergencyID",
                table: "Emergency_Status_Change");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergency_Status_Change",
                table: "Emergency_Status_Change");

            migrationBuilder.RenameTable(
                name: "Emergency_Status_Change",
                newName: "Emergency_Status_Changes");

            migrationBuilder.RenameIndex(
                name: "IX_Emergency_Status_Change_User_EmergencyID",
                table: "Emergency_Status_Changes",
                newName: "IX_Emergency_Status_Changes_User_EmergencyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes",
                columns: new[] { "UserID", "User_EmergencyID", "StatusPart" });

            migrationBuilder.AddForeignKey(
                name: "FK_Emergency_Status_Changes_AspNetUsers_UserID",
                table: "Emergency_Status_Changes",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emergency_Status_Changes_User_Emergency_User_EmergencyID",
                table: "Emergency_Status_Changes",
                column: "User_EmergencyID",
                principalTable: "User_Emergency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergency_Status_Changes_AspNetUsers_UserID",
                table: "Emergency_Status_Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Emergency_Status_Changes_User_Emergency_User_EmergencyID",
                table: "Emergency_Status_Changes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes");

            migrationBuilder.RenameTable(
                name: "Emergency_Status_Changes",
                newName: "Emergency_Status_Change");

            migrationBuilder.RenameIndex(
                name: "IX_Emergency_Status_Changes_User_EmergencyID",
                table: "Emergency_Status_Change",
                newName: "IX_Emergency_Status_Change_User_EmergencyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergency_Status_Change",
                table: "Emergency_Status_Change",
                columns: new[] { "UserID", "User_EmergencyID", "StatusPart" });

            migrationBuilder.AddForeignKey(
                name: "FK_Emergency_Status_Change_AspNetUsers_UserID",
                table: "Emergency_Status_Change",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emergency_Status_Change_User_Emergency_User_EmergencyID",
                table: "Emergency_Status_Change",
                column: "User_EmergencyID",
                principalTable: "User_Emergency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
