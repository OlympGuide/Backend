using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class AddSportFieldCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "sport_fields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sport_field_category",
                table: "sport_field_proposals",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "sport_fields");

            migrationBuilder.DropColumn(
                name: "sport_field_category",
                table: "sport_field_proposals");
        }
    }
}
