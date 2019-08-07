using System;
using System.Collections.Generic;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using BaseEntity = Microting.eFormApi.BasePn.Infrastructure.Database.Base.BaseEntity;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DescriptionFolders : BaseEntity
    {
        public DescriptionFolders()
        {            
            Children = new HashSet<DescriptionFolders>();
            
        }
        
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        
        public int SdkFolderId { get; set; }

        public virtual DescriptionFolders Parent { get; set; }

        public virtual ICollection<DescriptionFolders> Children { get; set; }


        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.DescriptionFolderse.Add(this);
            dbContext.SaveChanges();

            dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            DescriptionFolders descriptionFolders = dbContext.DescriptionFolderse.FirstOrDefault(x => x.Id == Id);

            if (descriptionFolders == null)
            {
                throw new NullReferenceException($"Could not find Desxcription Folder with id {Id}");
            }

            descriptionFolders.Name = Name;
            descriptionFolders.ParentId = ParentId;
            descriptionFolders.SdkFolderId = SdkFolderId;
            descriptionFolders.Children = Children;
            descriptionFolders.Parent = Parent;

            if (dbContext.ChangeTracker.HasChanges())
            {
                descriptionFolders.UpdatedAt = DateTime.Now;
                descriptionFolders.Version += 1;
                
                dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
                dbContext.SaveChanges();
                
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            DescriptionFolders descriptionFolders = dbContext.DescriptionFolderse.FirstOrDefault(x => x.Id == Id);

            if (descriptionFolders == null)
            {
                throw new NullReferenceException($"Could not find Desxcription Folder with id {Id}");
            }
            
            descriptionFolders.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                descriptionFolders.UpdatedAt = DateTime.Now;
                descriptionFolders.Version += 1;
                
                dbContext.DescriptionFoldersVersions.Add(MapVersions(dbContext, this));
                dbContext.SaveChanges();
                
            } 
        }

        public DescriptionFolderVersions MapVersions(CaseTemplatePnDbContext dbContext,
            DescriptionFolders descriptionFolders)
        {
            DescriptionFolderVersions descriptionFolderVersions = new DescriptionFolderVersions();

            descriptionFolderVersions.Name = descriptionFolders.Name;
            descriptionFolderVersions.ParentId = descriptionFolders.ParentId;
            descriptionFolderVersions.SdkFolderId = descriptionFolders.SdkFolderId;
            descriptionFolderVersions.Version = descriptionFolders.Version;
            descriptionFolderVersions.CreatedAt = descriptionFolders.CreatedAt;
            descriptionFolderVersions.UpdatedAt = descriptionFolders.UpdatedAt;
            descriptionFolderVersions.CreatedByUserId = descriptionFolders.CreatedByUserId;
            descriptionFolderVersions.UpdatedByUserId = descriptionFolders.UpdatedByUserId;
            descriptionFolderVersions.WorkflowState = descriptionFolders.WorkflowState;

            descriptionFolderVersions.DescriptionFolderId = descriptionFolders.Id;

            return descriptionFolderVersions;
        }
    }
}