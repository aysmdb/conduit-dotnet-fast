using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealDotnetFast.Migrations
{
    /// <inheritdoc />
    public partial class delfollow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_user",
                columns: table => new
                {
                    followed_by_id = table.Column<int>(type: "integer", nullable: false),
                    following_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_user", x => new { x.followed_by_id, x.following_id });
                    table.ForeignKey(
                        name: "fk_user_user_users_followed_by_id",
                        column: x => x.followed_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_user_users_following_id",
                        column: x => x.following_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_user_following_id",
                table: "user_user",
                column: "following_id");
        }
    }
}
