using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    /// <inheritdoc />
    public partial class AddExtensionForDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "DocumentUploadedDataVersions",
                type: "longtext",
                defaultValue: "pdf", // for set old files to pdf
				nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "DocumentUploadedDatas",
                type: "longtext",
                defaultValue: "pdf", // for set old files to pdf
				nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExtensionFile",
                table: "DocumentTranslationVersions",
                type: "longtext",
                defaultValue: "pdf", // for set old files to pdf
				nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExtensionFile",
                table: "DocumentTranslations",
                type: "longtext",
                defaultValue: "pdf", // for set old files to pdf
				nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "DocumentUploadedDataVersions");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "DocumentUploadedDatas");

            migrationBuilder.DropColumn(
                name: "ExtensionFile",
                table: "DocumentTranslationVersions");

            migrationBuilder.DropColumn(
                name: "ExtensionFile",
                table: "DocumentTranslations");
        }
    }
}
