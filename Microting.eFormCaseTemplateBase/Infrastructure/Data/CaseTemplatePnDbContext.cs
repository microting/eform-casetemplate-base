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

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data
{
    public class CaseTemplatePnDbContext : DbContext, IPluginDbContext
    {

        public CaseTemplatePnDbContext() { }

        public CaseTemplatePnDbContext(DbContextOptions<CaseTemplatePnDbContext> options) 
            : base(options)
        {
        }
        
        public DbSet<Cases> Cases { get; set; }
        public DbSet<CaseVersions> CaseVersionses { get; set; }
        public DbSet<CaseTemplates> CaseTemplateses { get; set; }
        public DbSet<CaseTemplateVersions> CaseTemplateseVersions { get; set; }
        public DbSet<CaseTemplateSites> CaseTemplateSites { get; set; }
        public DbSet<CaseTemplateSiteVersions> CaseTemplateSiteVersions { get; set; }
        public DbSet<CaseTemplateSiteGroups> CaseTemplateSiteGroups { get; set; }
        public DbSet<CaseTemplateSiteGroupVersions> CaseTemplateSiteGroupVersions { get; set; }
        public DbSet<DescriptionFolders> DescriptionFolderse { get; set; }
        public DbSet<DescriptionFolderVersions> DescriptionFoldersVersions { get; set; }
        public DbSet<UploadedDatas> UploadedDatas { get; set; }
        public DbSet<UploadedDataVersions> UploadedDataVersions { get; set; }
        public DbSet<CaseTemplateUploadedDatas> CaseTemplateUploadedDatas { get; set; }
        public DbSet<CaseTemplateUploadedDataVersions> CaseTemplateUploadedDataVersions { get; set; }
        
        // plugin settings
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}