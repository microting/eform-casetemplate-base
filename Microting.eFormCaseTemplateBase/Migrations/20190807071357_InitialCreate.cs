using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormCaseTemplateBase.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "CaseTemplateses",
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
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    StartAt = table.Column<DateTime>(nullable: false),
                    EndAt = table.Column<DateTime>(nullable: false),
                    PdfTitle = table.Column<string>(nullable: true),
                    Approvable = table.Column<bool>(nullable: false),
                    RetractIfApproved = table.Column<bool>(nullable: false),
                    AlwaysShow = table.Column<bool>(nullable: false),
                    DescriptionFolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateseVersions",
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
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    StartAt = table.Column<DateTime>(nullable: false),
                    EndAt = table.Column<DateTime>(nullable: false),
                    PdfTitle = table.Column<string>(nullable: true),
                    Approvable = table.Column<bool>(nullable: false),
                    RetractIfApproved = table.Column<bool>(nullable: false),
                    AlwaysShow = table.Column<bool>(nullable: false),
                    DescriptionFolderId = table.Column<int>(nullable: false),
                    CaseTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateseVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSiteGroups",
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
                    SdkSiteGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSiteGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSiteGroupVersions",
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
                    SdkSiteGroupId = table.Column<int>(nullable: false),
                    CaseTemplateSiteGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSiteGroupVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSites",
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
                    SdkSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSiteVersions",
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
                    SdkSiteId = table.Column<int>(nullable: false),
                    CaseTemplateSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSiteVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionFolderse",
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
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    SdkFolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionFolderse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionFolderse_DescriptionFolderse_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DescriptionFolderse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionFoldersVersions",
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
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    SdkFolderId = table.Column<int>(nullable: false),
                    DescriptionFolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionFoldersVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
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
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
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
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDatas",
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
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Local = table.Column<short>(nullable: true),
                    OriginalFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDataVersions",
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
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Local = table.Column<short>(nullable: true),
                    OriginalFileName = table.Column<string>(nullable: true),
                    UploadedDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDataVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
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
                    Status = table.Column<int>(nullable: true),
                    DoneAt = table.Column<DateTime>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true),
                    WorkerId = table.Column<int>(nullable: true),
                    eFormId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 255, nullable: true),
                    CaseTemplateId = table.Column<int>(nullable: false),
                    FetchedByTablet = table.Column<bool>(nullable: false),
                    FetchedByTabletAt = table.Column<DateTime>(nullable: false),
                    ReceiptRetrievedFromUser = table.Column<bool>(nullable: false),
                    ReceiptRetrievedFromUserAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_CaseTemplateses_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplateses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseVersionses",
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
                    Status = table.Column<int>(nullable: true),
                    DoneAt = table.Column<DateTime>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true),
                    WorkerId = table.Column<int>(nullable: true),
                    eFormId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 255, nullable: true),
                    CaseTemplateId = table.Column<int>(nullable: false),
                    FetchedByTablet = table.Column<bool>(nullable: false),
                    FetchedByTabletAt = table.Column<DateTime>(nullable: false),
                    ReceiptRetrievedFromUser = table.Column<bool>(nullable: false),
                    ReceiptRetrievedFromUserAt = table.Column<DateTime>(nullable: false),
                    CaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseVersionses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseVersionses_CaseTemplateses_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplateses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseTemplateId",
                table: "Cases",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVersionses_CaseTemplateId",
                table: "CaseVersionses",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionFolderse_ParentId",
                table: "DescriptionFolderse",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CaseTemplateseVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteGroups");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteGroupVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateSites");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteVersions");

            migrationBuilder.DropTable(
                name: "CaseVersionses");

            migrationBuilder.DropTable(
                name: "DescriptionFolderse");

            migrationBuilder.DropTable(
                name: "DescriptionFoldersVersions");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "UploadedDatas");

            migrationBuilder.DropTable(
                name: "UploadedDataVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateses");
        }
    }
}
