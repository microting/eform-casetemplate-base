using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingFolderPropertyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FolderProperties_FolderId",
                table: "FolderProperties",
                column: "FolderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FolderProperties_Folders_FolderId",
                table: "FolderProperties",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderProperties_Folders_FolderId",
                table: "FolderProperties");

            migrationBuilder.DropIndex(
                name: "IX_FolderProperties_FolderId",
                table: "FolderProperties");
        }
    }
}
