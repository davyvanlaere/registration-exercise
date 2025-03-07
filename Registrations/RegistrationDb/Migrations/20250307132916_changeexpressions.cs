using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Db.Migrations
{
    /// <inheritdoc />
    public partial class changeexpressions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "facebook",
                column: "ValidationRegex",
                value: "facebook");

            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "instagram",
                column: "ValidationRegex",
                value: "instagram");

            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "linkedin",
                column: "ValidationRegex",
                value: "linkedin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "facebook",
                column: "ValidationRegex",
                value: "(?:https?:)?\\/\\/(?:www\\.)?(?:facebook|fb)\\.com\\/(?P<profile>(?![A-z]+\\.php)(?!marketplace|gaming|watch|me|messages|help|search|groups)[A-z0-9_\\-\\.]+)\\/?");

            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "instagram",
                column: "ValidationRegex",
                value: "(?:https?:)?\\/\\/(?:www\\.)?(?:instagram\\.com|instagr\\.am)\\/(?P<username>[A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\\.(?!\\.))){0,28}(?:[A-Za-z0-9_]))?)");

            migrationBuilder.UpdateData(
                table: "SocialMediaPlatforms",
                keyColumn: "Id",
                keyValue: "linkedin",
                column: "ValidationRegex",
                value: "(?:https?:)?\\/\\/(?:[\\w]+\\.)?linkedin\\.com\\/(?P<company_type>(company)|(school))\\/(?P<company_permalink>[A-z0-9-À-ÿ\\.]+)\\/?");
        }
    }
}
