using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealDotnetFast.Migrations
{
    /// <inheritdoc />
    public partial class author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_users_author_id",
                table: "articles");

            migrationBuilder.DropIndex(
                name: "ix_articles_author_id",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "articles");
        }
    }
}
