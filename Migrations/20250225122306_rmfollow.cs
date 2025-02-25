using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealDotnetFast.Migrations
{
    /// <inheritdoc />
    public partial class rmfollow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_users_user_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_users_users_user_id1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_user_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_user_id1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_user_id",
                table: "users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_id1",
                table: "users",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_users_users_user_id",
                table: "users",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_users_user_id1",
                table: "users",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
