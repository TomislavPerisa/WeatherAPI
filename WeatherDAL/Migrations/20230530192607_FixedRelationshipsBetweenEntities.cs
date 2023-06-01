using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationshipsBetweenEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_weatherDatas_cities_CityId",
                table: "weatherDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_weatherDetails_weatherDatas_WeatherDataId",
                table: "weatherDetails");

            migrationBuilder.DropIndex(
                name: "IX_weatherDetails_WeatherDataId",
                table: "weatherDetails");

            migrationBuilder.DropIndex(
                name: "IX_weatherDatas_CityId",
                table: "weatherDatas");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDetails_IdWeatherData",
                table: "weatherDetails",
                column: "IdWeatherData");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_IdCity",
                table: "weatherDatas",
                column: "IdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_weatherDatas_cities_IdCity",
                table: "weatherDatas",
                column: "IdCity",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weatherDetails_weatherDatas_IdWeatherData",
                table: "weatherDetails",
                column: "IdWeatherData",
                principalTable: "weatherDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_weatherDatas_cities_IdCity",
                table: "weatherDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_weatherDetails_weatherDatas_IdWeatherData",
                table: "weatherDetails");

            migrationBuilder.DropIndex(
                name: "IX_weatherDetails_IdWeatherData",
                table: "weatherDetails");

            migrationBuilder.DropIndex(
                name: "IX_weatherDatas_IdCity",
                table: "weatherDatas");

            migrationBuilder.AddColumn<int>(
                name: "WeatherDataId",
                table: "weatherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "weatherDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_weatherDetails_WeatherDataId",
                table: "weatherDetails",
                column: "WeatherDataId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_CityId",
                table: "weatherDatas",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_weatherDatas_cities_CityId",
                table: "weatherDatas",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weatherDetails_weatherDatas_WeatherDataId",
                table: "weatherDetails",
                column: "WeatherDataId",
                principalTable: "weatherDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
