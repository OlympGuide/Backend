using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileToProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_sport_field_proposals_user_id",
                table: "sport_field_proposals",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_sport_field_proposals_users_user_id",
                table: "sport_field_proposals",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sport_field_proposals_users_user_id",
                table: "sport_field_proposals");

            migrationBuilder.DropIndex(
                name: "ix_sport_field_proposals_user_id",
                table: "sport_field_proposals");
        }
    }
}
