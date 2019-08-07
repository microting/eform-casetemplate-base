using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplates : BaseEntity
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
        
        public virtual ICollection<CaseTemplateUploadedDatas> CaseTemplateUploadedDatas { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.CaseTemplateses.Add(this);
            dbContext.SaveChanges();

            dbContext.CaseTemplateseVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplates caseTemplates = dbContext.CaseTemplateses.FirstOrDefault(x => x.Id == Id);

            if (caseTemplates == null)
            {
                throw new NullReferenceException($"Could not find Case Template with id {Id}");
            }

            caseTemplates.Approvable = Approvable;
            caseTemplates.Body = Body;
            caseTemplates.Title = Title;
            caseTemplates.AlwaysShow = AlwaysShow;
            caseTemplates.EndAt = EndAt;
            caseTemplates.PdfTitle = PdfTitle;
            caseTemplates.StartAt = StartAt;
            caseTemplates.RetractIfApproved = RetractIfApproved;
            caseTemplates.DescriptionFolderId = DescriptionFolderId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplates.Version += 1;
                caseTemplates.UpdatedAt = DateTime.Now;
                
                dbContext.CaseTemplateseVersions.Add(MapVersions(dbContext, caseTemplates));
                dbContext.SaveChanges();
            }

        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplates caseTemplates = dbContext.CaseTemplateses.FirstOrDefault(x => x.Id == Id);

            if (caseTemplates == null)
            {
                throw new NullReferenceException($"Could not find Case Template with id {Id}");
            }

            caseTemplates.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplates.Version += 1;
                caseTemplates.UpdatedAt = DateTime.Now;
                
                dbContext.CaseTemplateseVersions.Add(MapVersions(dbContext, caseTemplates));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateVersions MapVersions(CaseTemplatePnDbContext dbContext, CaseTemplates caseTemplates)
        {
            CaseTemplateVersions caseTemplateVersions = new CaseTemplateVersions();
            caseTemplateVersions.Approvable = caseTemplates.Approvable;
            caseTemplateVersions.Body = caseTemplates.Body;
            caseTemplateVersions.Title = caseTemplates.Title;
            caseTemplateVersions.AlwaysShow = caseTemplates.AlwaysShow;
            caseTemplateVersions.EndAt = caseTemplates.EndAt;
            caseTemplateVersions.PdfTitle = caseTemplates.PdfTitle;
            caseTemplateVersions.StartAt = caseTemplates.StartAt;
            caseTemplateVersions.RetractIfApproved = caseTemplates.RetractIfApproved;
            caseTemplateVersions.DescriptionFolderId = caseTemplates.DescriptionFolderId;
            caseTemplateVersions.Version = caseTemplates.Version;
            caseTemplateVersions.CreatedAt = caseTemplates.CreatedAt;
            caseTemplateVersions.UpdatedAt = caseTemplates.UpdatedAt;
            caseTemplateVersions.WorkflowState = caseTemplates.WorkflowState;
            caseTemplateVersions.CreatedByUserId = caseTemplates.CreatedByUserId;
            caseTemplateVersions.UpdatedByUserId = caseTemplates.UpdatedByUserId;

            caseTemplateVersions.CaseTemplateId = caseTemplates.Id;
            return caseTemplateVersions;
        }
    }
}