using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingIsLockedToDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "DocumentVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Documents",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Documents");
        }
    }
}
