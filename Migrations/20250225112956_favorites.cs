using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealDotnetFast.Migrations
{
    /// <inheritdoc />
    public partial class favorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_users_author_id",
                table: "articles");

            migrationBuilder.DropIndex(
                name: "ix_articles_author_id",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "article_alt_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "articles");

            migrationBuilder.CreateTable(
                name: "article_user",
                columns: table => new
                {
                    favorited_by_id = table.Column<int>(type: "integer", nullable: false),
                    favorites_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_article_user", x => new { x.favorited_by_id, x.favorites_id });
                    table.ForeignKey(
                        name: "fk_article_user_articles_favorites_id",
                        column: x => x.favorites_id,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_article_user_users_favorited_by_id",
                        column: x => x.favorited_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_article_user_favorites_id",
                table: "article_user",
                column: "favorites_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_user");

            migrationBuilder.AddColumn<int>(
                name: "article_alt_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "articles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_articles_author_id",
                table: "articles",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "fk_articles_users_author_id",
                table: "articles",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
