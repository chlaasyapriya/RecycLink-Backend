using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Management_and_Recycling_System.Migrations
{
    /// <inheritdoc />
    public partial class Events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteers_Volunteers_VolunteerId",
                table: "EventVolunteers");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteers_Users_VolunteerId",
                table: "EventVolunteers",
                column: "VolunteerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteers_Users_VolunteerId",
                table: "EventVolunteers");

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalHoursWorked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK_Volunteers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_UserId",
                table: "Volunteers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteers_Volunteers_VolunteerId",
                table: "EventVolunteers",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "VolunteerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
