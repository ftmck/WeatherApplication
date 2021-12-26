using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class InitialMigrate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    Visibility = table.Column<int>(nullable: false),
                    DewPoint = table.Column<int>(nullable: false),
                    RelativeHumidity = table.Column<int>(nullable: false),
                    Pressure = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherHeader_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeatherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_WeatherHeader_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkyConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WeatherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkyConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkyConditions_WeatherHeader_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Temperature_Max = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Temperature_Min = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeatherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureDetails_WeatherHeader_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Degrees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gust = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeatherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Winds_WeatherHeader_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WeatherId",
                table: "Locations",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_SkyConditions_WeatherId",
                table: "SkyConditions",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureDetails_WeatherId",
                table: "TemperatureDetails",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherHeader_CityId",
                table: "WeatherHeader",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Winds_WeatherId",
                table: "Winds",
                column: "WeatherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SkyConditions");

            migrationBuilder.DropTable(
                name: "TemperatureDetails");

            migrationBuilder.DropTable(
                name: "Winds");

            migrationBuilder.DropTable(
                name: "WeatherHeader");
        }
    }
}
