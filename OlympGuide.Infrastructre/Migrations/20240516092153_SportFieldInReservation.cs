using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class SportFieldInReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_reservations_sport_field_id",
                table: "reservations",
                column: "sport_field_id");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_sport_fields_sport_field_id",
                table: "reservations",
                column: "sport_field_id",
                principalTable: "sport_fields",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reservations_sport_fields_sport_field_id",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "ix_reservations_sport_field_id",
                table: "reservations");
        }
    }
}
