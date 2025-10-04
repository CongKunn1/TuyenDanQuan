using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMissionCitizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissionCitizen",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionCitizen", x => new { x.MissionId, x.CitizenId });
                    table.ForeignKey(
                        name: "FK_MissionCitizen_Citizen_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionCitizen_Mission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionCitizen_CitizenId",
                table: "MissionCitizen",
                column: "CitizenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionCitizen");
        }
    }
}
