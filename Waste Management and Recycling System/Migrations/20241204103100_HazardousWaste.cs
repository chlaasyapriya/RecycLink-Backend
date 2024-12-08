using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Management_and_Recycling_System.Migrations
{
    /// <inheritdoc />
    public partial class HazardousWaste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HazardousWastes_RecyclingPlants_FacilityId",
                table: "HazardousWastes");

            migrationBuilder.DropForeignKey(
                name: "FK_HazardousWastes_Users_CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropIndex(
                name: "IX_HazardousWastes_CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropIndex(
                name: "IX_HazardousWastes_FacilityId",
                table: "HazardousWastes");

            migrationBuilder.DropColumn(
                name: "CollectorId",
                table: "HazardousWastes");

            migrationBuilder.DropColumn(
                name: "DisposalDate",
                table: "HazardousWastes");

            migrationBuilder.DropColumn(
                name: "FacilityId",
                table: "HazardousWastes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectorId",
                table: "HazardousWastes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisposalDate",
                table: "HazardousWastes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacilityId",
                table: "HazardousWastes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HazardousWastes_CollectorId",
                table: "HazardousWastes",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_HazardousWastes_FacilityId",
                table: "HazardousWastes",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HazardousWastes_RecyclingPlants_FacilityId",
                table: "HazardousWastes",
                column: "FacilityId",
                principalTable: "RecyclingPlants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HazardousWastes_Users_CollectorId",
                table: "HazardousWastes",
                column: "CollectorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
