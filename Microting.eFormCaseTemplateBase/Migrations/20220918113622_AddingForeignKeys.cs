using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "CaseTemplateTranslationVersions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CaseTemplateId",
                table: "CaseTemplateTranslationVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PdfTitle",
                table: "CaseTemplateTranslationVersions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CaseTemplateTranslationVersions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CaseTemplateId",
                table: "CaseTemplateTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateTranslations_CaseTemplateId",
                table: "CaseTemplateTranslations",
                column: "CaseTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTemplateTranslations_CaseTemplates_CaseTemplateId",
                table: "CaseTemplateTranslations",
                column: "CaseTemplateId",
                principalTable: "CaseTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTemplateTranslations_CaseTemplates_CaseTemplateId",
                table: "CaseTemplateTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CaseTemplateTranslations_CaseTemplateId",
                table: "CaseTemplateTranslations");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "CaseTemplateTranslationVersions");

            migrationBuilder.DropColumn(
                name: "CaseTemplateId",
                table: "CaseTemplateTranslationVersions");

            migrationBuilder.DropColumn(
                name: "PdfTitle",
                table: "CaseTemplateTranslationVersions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CaseTemplateTranslationVersions");

            migrationBuilder.DropColumn(
                name: "CaseTemplateId",
                table: "CaseTemplateTranslations");
        }
    }
}
