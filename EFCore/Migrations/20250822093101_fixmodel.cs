using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class fixmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "RewardProposal");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "RewardApproval");

            migrationBuilder.DropColumn(
                name: "DisciplineProposalId",
                table: "DisciplineProposal");

            migrationBuilder.DropColumn(
                name: "ApprovedByCitizenId",
                table: "DisciplineApproval");

            migrationBuilder.DropColumn(
                name: "DisciplineApprovalId",
                table: "DisciplineApproval");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProposalId",
                table: "RewardProposal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalId",
                table: "RewardApproval",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplineProposalId",
                table: "DisciplineProposal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByCitizenId",
                table: "DisciplineApproval",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplineApprovalId",
                table: "DisciplineApproval",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
