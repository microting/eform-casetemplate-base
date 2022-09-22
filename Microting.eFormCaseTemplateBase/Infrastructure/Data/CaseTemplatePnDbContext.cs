/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Microsoft.EntityFrameworkCore;
using Microting.eForm.Dto;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using Case = Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities.Case;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data
{
    public class CaseTemplatePnDbContext : DbContext, IPluginDbContext
    {

        public CaseTemplatePnDbContext() { }

        public CaseTemplatePnDbContext(DbContextOptions<CaseTemplatePnDbContext> options)
            : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseVersion> CaseVersions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<DocumentSite> DocumentSites { get; set; }
        public DbSet<DocumentSiteVersion> DocumentSiteVersions { get; set; }
        public DbSet<DocumentSiteTag> DocumentSiteTags { get; set; }
        public DbSet<DocumentSiteTagVersion> DocumentSiteTagVersions { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FolderVersion> FolderVersions { get; set; }
        public DbSet<FolderTranslation> FolderTranslations { get; set; }
        public DbSet<FolderTranslationVersion> FolderTranslationVersions { get; set; }
        public DbSet<FolderProperty> FolderProperties { get; set; }
        public DbSet<FolderPropertyVersion> FolderPropertyVersions { get; set; }
        public DbSet<UploadedData> UploadedDatas { get; set; }
        public DbSet<UploadedDataVersion> UploadedDataVersions { get; set; }
        public DbSet<DocumentUploadedData> DocumentUploadedDatas { get; set; }
        public DbSet<DocumentUploadedDataVersion> DocumentUploadedDataVersions { get; set; }
        public DbSet<DocumentTranslation> DocumentTranslations { get; set; }
        public DbSet<DocumentTranslationVersion> DocumentTranslationVersions { get; set; }

        // plugin settings
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
        public DbSet<PluginPermission> PluginPermissions { get; set; }
        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}