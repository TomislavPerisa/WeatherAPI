using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "weatherDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnapshotTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    All = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Temp = table.Column<double>(type: "float", nullable: false),
                    Feels_like = table.Column<double>(type: "float", nullable: false),
                    Temp_min = table.Column<double>(type: "float", nullable: false),
                    Temp_max = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Rain1h = table.Column<double>(type: "float", nullable: true),
                    Rain3h = table.Column<double>(type: "float", nullable: true),
                    Snow1h = table.Column<double>(type: "float", nullable: true),
                    Snow3h = table.Column<double>(type: "float", nullable: true),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    Dt = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SunriseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SunsetTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Deg = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_weatherDatas_cities_CityId",
                        column: x => x.IdCity,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weatherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdWeatherData = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_weatherDetails_weatherDatas_WeatherDataId",
                        column: x => x.IdWeatherData,
                        principalTable: "weatherDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_CityId",
                table: "weatherDatas",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDetails_WeatherDataId",
                table: "weatherDetails",
                column: "IdWeatherData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weatherDetails");

            migrationBuilder.DropTable(
                name: "weatherDatas");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
