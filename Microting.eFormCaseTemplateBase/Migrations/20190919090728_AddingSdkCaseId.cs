using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingSdkCaseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SdkCaseId",
                table: "CaseTemplateSiteVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SdkCaseId",
                table: "CaseTemplateSites",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkCaseId",
                table: "CaseTemplateSiteVersions");

            migrationBuilder.DropColumn(
                name: "SdkCaseId",
                table: "CaseTemplateSites");
        }
    }
}
