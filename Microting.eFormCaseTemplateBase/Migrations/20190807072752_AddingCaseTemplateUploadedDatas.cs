using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class AddingCaseTemplateUploadedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider
           
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue= SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider=="Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "CaseTemplateUploadedDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CaseTemplateId = table.Column<int>(nullable: false),
                    UploadedDataId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Approvable = table.Column<bool>(nullable: false),
                    RetractIfApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateUploadedDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDatas_CaseTemplateses_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplateses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDatas_UploadedDatas_UploadedDataId",
                        column: x => x.UploadedDataId,
                        principalTable: "UploadedDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateUploadedDataVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CaseTemplateId = table.Column<int>(nullable: false),
                    UploadedDataId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Approvable = table.Column<bool>(nullable: false),
                    RetractIfApproved = table.Column<bool>(nullable: false),
                    CaseTemplatesId = table.Column<int>(nullable: true),
                    UploadedDatasId = table.Column<int>(nullable: true),
                    CaseTemplateUploadedDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateUploadedDataVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDataVersions_CaseTemplateses_CaseTemplatesId",
                        column: x => x.CaseTemplatesId,
                        principalTable: "CaseTemplateses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDataVersions_UploadedDatas_UploadedDatasId",
                        column: x => x.UploadedDatasId,
                        principalTable: "UploadedDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDatas_CaseTemplateId",
                table: "CaseTemplateUploadedDatas",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDatas_UploadedDataId",
                table: "CaseTemplateUploadedDatas",
                column: "UploadedDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDataVersions_CaseTemplatesId",
                table: "CaseTemplateUploadedDataVersions",
                column: "CaseTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDataVersions_UploadedDatasId",
                table: "CaseTemplateUploadedDataVersions",
                column: "UploadedDatasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseTemplateUploadedDatas");

            migrationBuilder.DropTable(
                name: "CaseTemplateUploadedDataVersions");
        }
    }
}
