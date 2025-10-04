using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class EditmodelMission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Citizen_CitizenId",
                table: "Mission");

            migrationBuilder.DropIndex(
                name: "IX_Mission_CitizenId",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Mission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenId",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mission_CitizenId",
                table: "Mission",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Citizen_CitizenId",
                table: "Mission",
                column: "CitizenId",
                principalTable: "Citizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
