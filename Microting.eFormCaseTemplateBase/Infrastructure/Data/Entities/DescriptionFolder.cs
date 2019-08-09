using System;
using System.Collections.Generic;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using BaseEntity = Microting.eFormApi.BasePn.Infrastructure.Database.Base.BaseEntity;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DescriptionFolder : BaseEntity
    {
        public DescriptionFolder()
        {            
            Children = new HashSet<DescriptionFolder>();
            
        }
        
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        
        public int SdkFolderId { get; set; }

        public virtual DescriptionFolder Parent { get; set; }

        public virtual ICollection<DescriptionFolder> Children { get; set; }


        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.DescriptionFolders.Add(this);
            dbContext.SaveChanges();

            dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            DescriptionFolder descriptionFolder = dbContext.DescriptionFolders.FirstOrDefault(x => x.Id == Id);

            if (descriptionFolder == null)
            {
                throw new NullReferenceException($"Could not find Desxcription Folder with id {Id}");
            }

            descriptionFolder.Name = Name;
            descriptionFolder.ParentId = ParentId;
            descriptionFolder.SdkFolderId = SdkFolderId;
            descriptionFolder.Children = Children;
            descriptionFolder.Parent = Parent;

            if (dbContext.ChangeTracker.HasChanges())
            {
                descriptionFolder.UpdatedAt = DateTime.Now;
                descriptionFolder.Version += 1;
                
                dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
                dbContext.SaveChanges();
                
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            DescriptionFolder descriptionFolder = dbContext.DescriptionFolders.FirstOrDefault(x => x.Id == Id);

            if (descriptionFolder == null)
            {
                throw new NullReferenceException($"Could not find Desxcription Folder with id {Id}");
            }
            
            descriptionFolder.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                descriptionFolder.UpdatedAt = DateTime.Now;
                descriptionFolder.Version += 1;
                
                dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
                dbContext.SaveChanges();
                
            } 
        }

        public DescriptionFolderVersion MapVersions(CaseTemplatePnDbContext dbContext,
            DescriptionFolder descriptionFolder)
        {
            DescriptionFolderVersion descriptionFolderVersion = new DescriptionFolderVersion();

            descriptionFolderVersion.Name = descriptionFolder.Name;
            descriptionFolderVersion.ParentId = descriptionFolder.ParentId;
            descriptionFolderVersion.SdkFolderId = descriptionFolder.SdkFolderId;
            descriptionFolderVersion.Version = descriptionFolder.Version;
            descriptionFolderVersion.CreatedAt = descriptionFolder.CreatedAt;
            descriptionFolderVersion.UpdatedAt = descriptionFolder.UpdatedAt;
            descriptionFolderVersion.CreatedByUserId = descriptionFolder.CreatedByUserId;
            descriptionFolderVersion.UpdatedByUserId = descriptionFolder.UpdatedByUserId;
            descriptionFolderVersion.WorkflowState = descriptionFolder.WorkflowState;

            descriptionFolderVersion.DescriptionFolderId = descriptionFolder.Id;

            return descriptionFolderVersion;
        }
    }
}