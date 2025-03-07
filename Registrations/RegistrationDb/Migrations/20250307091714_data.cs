using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Db.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SocialMediaPlatforms",
                columns: new[] { "Id", "ValidationRegex" },
                values: new object[,]
                {
                    { "facebook", "(?:https?:)?\\/\\/(?:www\\.)?(?:facebook|fb)\\.com\\/(?P<profile>(?![A-z]+\\.php)(?!marketplace|gaming|watch|me|messages|help|search|groups)[A-z0-9_\\-\\.]+)\\/?" },
                    { "instagram", "(?:https?:)?\\/\\/(?:www\\.)?(?:instagram\\.com|instagr\\.am)\\/(?P<username>[A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\\.(?!\\.))){0,28}(?:[A-Za-z0-9_]))?)" },
                    { "linkedin", "(?:https?:)?\\/\\/(?:[\\w]+\\.)?linkedin\\.com\\/(?P<company_type>(company)|(school))\\/(?P<company_permalink>[A-z0-9-À-ÿ\\.]+)\\/?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "facebook");

            migrationBuilder.DeleteData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "instagram");

            migrationBuilder.DeleteData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "linkedin");
        }
    }
}
