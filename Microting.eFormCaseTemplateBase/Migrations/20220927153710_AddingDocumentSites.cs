using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingDocumentSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DocumentSites_DocumentId",
                table: "DocumentSites",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentSites_Documents_DocumentId",
                table: "DocumentSites",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentSites_Documents_DocumentId",
                table: "DocumentSites");

            migrationBuilder.DropIndex(
                name: "IX_DocumentSites_DocumentId",
                table: "DocumentSites");
        }
    }
}
