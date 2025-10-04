using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteMissionCitizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionCitizen_Citizen_CitizenId",
                table: "MissionCitizen");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionCitizen_Mission_MissionId",
                table: "MissionCitizen");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionCitizen_Citizen_CitizenId",
                table: "MissionCitizen",
                column: "CitizenId",
                principalTable: "Citizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionCitizen_Mission_MissionId",
                table: "MissionCitizen",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionCitizen_Citizen_CitizenId",
                table: "MissionCitizen");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionCitizen_Mission_MissionId",
                table: "MissionCitizen");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionCitizen_Citizen_CitizenId",
                table: "MissionCitizen",
                column: "CitizenId",
                principalTable: "Citizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionCitizen_Mission_MissionId",
                table: "MissionCitizen",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
