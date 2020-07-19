using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightMaster.WebAPI.Migrations
{
    public partial class TicketJourneyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Journeys");

            migrationBuilder.AddColumn<string>(
                name: "TicketStatus",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Journeys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
