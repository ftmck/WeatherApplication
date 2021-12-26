using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class InitialMigrate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHeader_Cities_CityId",
                table: "WeatherHeader");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "WeatherHeader");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WeatherHeader",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHeader_Cities_CityId",
                table: "WeatherHeader",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHeader_Cities_CityId",
                table: "WeatherHeader");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WeatherHeader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "WeatherHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHeader_Cities_CityId",
                table: "WeatherHeader",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
