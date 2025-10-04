using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class Editmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Unit_UnitId",
                table: "Mission");

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_UnitId",
                table: "Citizen",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizen_Unit_UnitId",
                table: "Citizen",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Unit_UnitId",
                table: "Mission",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizen_Unit_UnitId",
                table: "Citizen");

            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Unit_UnitId",
                table: "Mission");

            migrationBuilder.DropIndex(
                name: "IX_Citizen_UnitId",
                table: "Citizen");

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Unit_UnitId",
                table: "Mission",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
