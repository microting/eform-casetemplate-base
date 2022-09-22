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
        public DbSet<CaseTemplate> CaseTemplates { get; set; }
        public DbSet<CaseTemplateVersion> CaseTemplateVersions { get; set; }
        public DbSet<CaseTemplateSite> CaseTemplateSites { get; set; }
        public DbSet<CaseTemplateSiteVersion> CaseTemplateSiteVersions { get; set; }
        public DbSet<CaseTemplateSiteTag> CaseTemplateSiteTags { get; set; }
        public DbSet<CaseTemplateSiteTagVersion> CaseTemplateSiteTagVersions { get; set; }
        public DbSet<Folder> DescriptionFolders { get; set; }
        public DbSet<FolderVersion> DescriptionFolderVersions { get; set; }
        public DbSet<FolderTranslation> FolderTranslations { get; set; }
        public DbSet<FolderTranslationVersion> FolderTranslationVersions { get; set; }
        public DbSet<FolderProperty> FolderProperties { get; set; }
        public DbSet<FolderPropertyVersion> FolderPropertyVersions { get; set; }
        public DbSet<UploadedData> UploadedDatas { get; set; }
        public DbSet<UploadedDataVersion> UploadedDataVersions { get; set; }
        public DbSet<CaseTemplateUploadedData> CaseTemplateUploadedDatas { get; set; }
        public DbSet<CaseTemplateUploadedDataVersion> CaseTemplateUploadedDataVersions { get; set; }
        public DbSet<CaseTemplateTranslation> CaseTemplateTranslations { get; set; }
        public DbSet<CaseTemplateTranslationVersion> CaseTemplateTranslationVersions { get; set; }

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