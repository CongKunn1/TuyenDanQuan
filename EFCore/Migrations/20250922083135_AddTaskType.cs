using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCommon.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DecisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_Citizen_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mission_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mission_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Code", "CreatedTime", "Description", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "TRAIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhiệm vụ huấn luyện dân quân", "Huấn luyện", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "PATROL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhiệm vụ tuần tra an ninh", "Tuần tra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "SUPPORT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ địa phương, cứu trợ", "Hỗ trợ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "DEFENSE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tham gia phòng thủ khi cần", "Phòng thủ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_CitizenId",
                table: "Mission",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_TaskTypeId",
                table: "Mission",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_UnitId",
                table: "Mission",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
