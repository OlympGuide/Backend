using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class AddSportFieldProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sport_field_proposals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sport_field_name = table.Column<string>(type: "text", nullable: false),
                    sport_field_description = table.Column<string>(type: "text", nullable: false),
                    sport_field_longitude = table.Column<float>(type: "real", nullable: false),
                    sport_field_latitude = table.Column<float>(type: "real", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sport_field_proposals", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sport_field_proposals");
        }
    }
}
