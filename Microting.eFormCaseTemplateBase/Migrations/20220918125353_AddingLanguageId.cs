using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingLanguageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CaseTemplateTranslationVersions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "CaseTemplateTranslationVersions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CaseTemplateTranslations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "CaseTemplateTranslations",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CaseTemplateTranslationVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CaseTemplateTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CaseTemplateTranslationVersions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CaseTemplateTranslations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CaseTemplateTranslationVersions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CaseTemplateTranslationVersions",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CaseTemplateTranslations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CaseTemplateTranslations",
                newName: "Body");
        }
    }
}
