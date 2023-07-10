using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedThePostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    PublishDate = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Published = table.Column<bool>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[,]
                {
                    { 1, "Marko Avram", 1, "", "This is the excerpt for post 1. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "First post" },
                    { 2, "Marko Avram", 2, "", "This is the excerpt for post 2. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "Second post" },
                    { 3, "Marko Avram", 3, "", "This is the excerpt for post 3. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "Third post" },
                    { 4, "Marko Avram", 1, "", "This is the excerpt for post 4. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "Fourth post" },
                    { 5, "Marko Avram", 2, "", "This is the excerpt for post 5. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "Fifth post" },
                    { 6, "Marko Avram", 3, "", "This is the excerpt for post 6. An excerpt is a little extraction from a larger piece of text. Sort of like a preview.", "10/07/2023 03:31", true, "uploads/placeholder.jpg", "Sixth post" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
