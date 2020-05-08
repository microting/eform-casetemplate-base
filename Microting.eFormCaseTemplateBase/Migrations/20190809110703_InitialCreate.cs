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

            var autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "CaseTemplates",
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
                    table.PrimaryKey("PK_CaseTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSiteTags",
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
                    SdkSiteTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSiteTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTemplateSiteTagVersions",
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
                    SdkSiteTagId = table.Column<int>(nullable: false),
                    CaseTemplateSiteTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateSiteTagVersions", x => x.Id);
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
                name: "CaseTemplateVersions",
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
                    table.PrimaryKey("PK_CaseTemplateVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionFolders",
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
                    table.PrimaryKey("PK_DescriptionFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionFolders_DescriptionFolders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DescriptionFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionFolderVersions",
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
                    table.PrimaryKey("PK_DescriptionFolderVersions", x => x.Id);
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
                        name: "FK_Cases_CaseTemplates_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseVersions",
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
                    table.PrimaryKey("PK_CaseVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseVersions_CaseTemplates_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_CaseTemplateUploadedDatas_CaseTemplates_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplates",
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
                    CaseTemplateUploadedDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTemplateUploadedDataVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDataVersions_CaseTemplates_CaseTemplateId",
                        column: x => x.CaseTemplateId,
                        principalTable: "CaseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTemplateUploadedDataVersions_UploadedDatas_UploadedDataId",
                        column: x => x.UploadedDataId,
                        principalTable: "UploadedDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseTemplateId",
                table: "Cases",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDatas_CaseTemplateId",
                table: "CaseTemplateUploadedDatas",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDatas_UploadedDataId",
                table: "CaseTemplateUploadedDatas",
                column: "UploadedDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDataVersions_CaseTemplateId",
                table: "CaseTemplateUploadedDataVersions",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTemplateUploadedDataVersions_UploadedDataId",
                table: "CaseTemplateUploadedDataVersions",
                column: "UploadedDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVersions_CaseTemplateId",
                table: "CaseVersions",
                column: "CaseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionFolders_ParentId",
                table: "DescriptionFolders",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteTags");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteTagVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateSites");

            migrationBuilder.DropTable(
                name: "CaseTemplateSiteVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateUploadedDatas");

            migrationBuilder.DropTable(
                name: "CaseTemplateUploadedDataVersions");

            migrationBuilder.DropTable(
                name: "CaseTemplateVersions");

            migrationBuilder.DropTable(
                name: "CaseVersions");

            migrationBuilder.DropTable(
                name: "DescriptionFolders");

            migrationBuilder.DropTable(
                name: "DescriptionFolderVersions");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "UploadedDataVersions");

            migrationBuilder.DropTable(
                name: "UploadedDatas");

            migrationBuilder.DropTable(
                name: "CaseTemplates");
        }
    }
}
