using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplate : BaseEntity
    {
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public DateTime StartAt { get; set; }
        
        public DateTime EndAt { get; set; }
        
        public string PdfTitle { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public bool AlwaysShow { get; set; }
        
        [ForeignKey("DescriptionFolders")]
        public int DescriptionFolderId { get; set; }
        
        public virtual ICollection<CaseTemplateUploadedData> CaseTemplateUploadedDatas { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.CaseTemplates.Add(this);
            dbContext.SaveChanges();

            dbContext.CaseTemplateVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplate caseTemplate = dbContext.CaseTemplates.FirstOrDefault(x => x.Id == Id);

            if (caseTemplate == null)
            {
                throw new NullReferenceException($"Could not find Case Template with id {Id}");
            }

            caseTemplate.Approvable = Approvable;
            caseTemplate.Body = Body;
            caseTemplate.Title = Title;
            caseTemplate.AlwaysShow = AlwaysShow;
            caseTemplate.EndAt = EndAt;
            caseTemplate.PdfTitle = PdfTitle;
            caseTemplate.StartAt = StartAt;
            caseTemplate.RetractIfApproved = RetractIfApproved;
            caseTemplate.DescriptionFolderId = DescriptionFolderId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplate.Version += 1;
                caseTemplate.UpdatedAt = DateTime.Now;
                
                dbContext.CaseTemplateVersions.Add(MapVersions(dbContext, caseTemplate));
                dbContext.SaveChanges();
            }

        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplate caseTemplate = dbContext.CaseTemplates.FirstOrDefault(x => x.Id == Id);

            if (caseTemplate == null)
            {
                throw new NullReferenceException($"Could not find Case Template with id {Id}");
            }

            caseTemplate.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplate.Version += 1;
                caseTemplate.UpdatedAt = DateTime.Now;
                
                dbContext.CaseTemplateVersions.Add(MapVersions(dbContext, caseTemplate));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateVersion MapVersions(CaseTemplatePnDbContext dbContext, CaseTemplate caseTemplate)
        {
            CaseTemplateVersion caseTemplateVersion = new CaseTemplateVersion();
            caseTemplateVersion.Approvable = caseTemplate.Approvable;
            caseTemplateVersion.Body = caseTemplate.Body;
            caseTemplateVersion.Title = caseTemplate.Title;
            caseTemplateVersion.AlwaysShow = caseTemplate.AlwaysShow;
            caseTemplateVersion.EndAt = caseTemplate.EndAt;
            caseTemplateVersion.PdfTitle = caseTemplate.PdfTitle;
            caseTemplateVersion.StartAt = caseTemplate.StartAt;
            caseTemplateVersion.RetractIfApproved = caseTemplate.RetractIfApproved;
            caseTemplateVersion.DescriptionFolderId = caseTemplate.DescriptionFolderId;
            caseTemplateVersion.Version = caseTemplate.Version;
            caseTemplateVersion.CreatedAt = caseTemplate.CreatedAt;
            caseTemplateVersion.UpdatedAt = caseTemplate.UpdatedAt;
            caseTemplateVersion.WorkflowState = caseTemplate.WorkflowState;
            caseTemplateVersion.CreatedByUserId = caseTemplate.CreatedByUserId;
            caseTemplateVersion.UpdatedByUserId = caseTemplate.UpdatedByUserId;

            caseTemplateVersion.CaseTemplateId = caseTemplate.Id;
            return caseTemplateVersion;
        }
    }
}