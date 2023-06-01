using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalIdColumnToCitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "cities");
        }
    }
}
