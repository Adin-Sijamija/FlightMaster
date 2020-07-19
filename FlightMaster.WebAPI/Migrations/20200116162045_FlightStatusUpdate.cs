using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightMaster.WebAPI.Migrations
{
    public partial class FlightStatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
