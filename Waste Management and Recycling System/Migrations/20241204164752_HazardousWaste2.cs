using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Management_and_Recycling_System.Migrations
{
    /// <inheritdoc />
    public partial class HazardousWaste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectorId",
                table: "HazardousWastes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecyclingPlantId",
                table: "HazardousWastes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HazardousWastes_CollectorId",
                table: "HazardousWastes",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_HazardousWastes_RecyclingPlantId",
                table: "HazardousWastes",
                column: "RecyclingPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_HazardousWastes_RecyclingPlants_RecyclingPlantId",
                table: "HazardousWastes",
                column: "RecyclingPlantId",
                principalTable: "RecyclingPlants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HazardousWastes_Users_CollectorId",
                table: "HazardousWastes",
                column: "CollectorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HazardousWastes_RecyclingPlants_RecyclingPlantId",
                table: "HazardousWastes");

            migrationBuilder.DropForeignKey(
                name: "FK_HazardousWastes_Users_CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropIndex(
                name: "IX_HazardousWastes_CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropIndex(
                name: "IX_HazardousWastes_RecyclingPlantId",
                table: "HazardousWastes");

            migrationBuilder.DropColumn(
                name: "CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropColumn(
                name: "RecyclingPlantId",
                table: "HazardousWastes");
        }
    }
}
