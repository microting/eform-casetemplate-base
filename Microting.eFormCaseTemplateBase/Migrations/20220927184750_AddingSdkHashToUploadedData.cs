using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingSdkHashToUploadedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SdkHash",
                table: "DocumentUploadedDataVersions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SdkHash",
                table: "DocumentUploadedDatas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkHash",
                table: "DocumentUploadedDataVersions");

            migrationBuilder.DropColumn(
                name: "SdkHash",
                table: "DocumentUploadedDatas");
        }
    }
}
