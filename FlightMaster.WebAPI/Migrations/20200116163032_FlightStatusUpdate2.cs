using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightMaster.WebAPI.Migrations
{
    public partial class FlightStatusUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.DropIndex(
                name: "IX_Flights_Airfield2Id",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_Airfield1Id",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airfields_Airfield1Id",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airfields_Airfield2Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirfieldId1",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirfieldId2",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "Airfield2Id",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Airfield1Id",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airfields_Airfield1Id",
                table: "Flights",
                column: "Airfield1Id",
                principalTable: "Airfields",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airfields_Airfield2Id",
                table: "Flights",
                column: "Airfield2Id",
                principalTable: "Airfields",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airfields_Airfield1Id",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airfields_Airfield2Id",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "Airfield2Id",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Airfield1Id",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AirfieldId1",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirfieldId2",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airfields_Airfield1Id",
                table: "Flights",
                column: "Airfield1Id",
                principalTable: "Airfields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airfields_Airfield2Id",
                table: "Flights",
                column: "Airfield2Id",
                principalTable: "Airfields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
