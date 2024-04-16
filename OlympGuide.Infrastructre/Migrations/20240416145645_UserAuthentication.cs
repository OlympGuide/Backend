using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class UserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthenticationUserMappings",
                table: "AuthenticationUserMappings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "AuthenticationUserMappings",
                newName: "authentication_user_mappings");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "users",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "users",
                newName: "display_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "authentication_user_mappings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "authentication_user_mappings",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "AuthenticationProviderId",
                table: "authentication_user_mappings",
                newName: "authentication_provider_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_authentication_user_mappings",
                table: "authentication_user_mappings",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_authentication_user_mappings",
                table: "authentication_user_mappings");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "authentication_user_mappings",
                newName: "AuthenticationUserMappings");

            migrationBuilder.RenameColumn(
                name: "roles",
                table: "Users",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "display_name",
                table: "Users",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AuthenticationUserMappings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AuthenticationUserMappings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "authentication_provider_id",
                table: "AuthenticationUserMappings",
                newName: "AuthenticationProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthenticationUserMappings",
                table: "AuthenticationUserMappings",
                column: "Id");
        }
    }
}
