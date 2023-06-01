using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIdExternalColumnToCitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalId",
                table: "cities",
                newName: "IdExternal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdExternal",
                table: "cities",
                newName: "ExternalId");
        }
    }
}
