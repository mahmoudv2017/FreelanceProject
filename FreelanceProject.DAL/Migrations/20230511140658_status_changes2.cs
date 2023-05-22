using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class status_changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes",
                columns: new[] { "UserID", "User_EmergencyID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergency_Status_Changes",
                table: "Emergency_Status_Changes",
                columns: new[] { "UserID", "User_EmergencyID", "StatusPart" });
        }
    }
}
