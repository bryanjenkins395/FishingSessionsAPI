using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSessionsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCatchEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishingSessionId = table.Column<int>(type: "int", nullable: false),
                    CaughtAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catches_FishingSessions_FishingSessionId",
                        column: x => x.FishingSessionId,
                        principalTable: "FishingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catches_FishingSessionId",
                table: "Catches",
                column: "FishingSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catches");
        }
    }
}
