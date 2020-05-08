using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteTag : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteTagId { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            dbContext.CaseTemplateSiteTags.Add(this);
            dbContext.SaveChanges();
            dbContext.CaseTemplateSiteTagVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSiteTag caseTemplateSiteTag =
                dbContext.CaseTemplateSiteTags.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteTag == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteTag.CaseTemplateId = CaseTemplateId;
            caseTemplateSiteTag.SdkSiteTagId = SdkSiteTagId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteTag.UpdatedAt = DateTime.Now;
                caseTemplateSiteTag.Version += 1;

                dbContext.CaseTemplateSiteTagVersions.Add(MapVersions(dbContext, caseTemplateSiteTag));
                dbContext.SaveChanges();
            }
        }


        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSiteTag caseTemplateSiteTag =
                dbContext.CaseTemplateSiteTags.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteTag == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteTag.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteTag.UpdatedAt = DateTime.Now;
                caseTemplateSiteTag.Version += 1;

                dbContext.CaseTemplateSiteTagVersions.Add(MapVersions(dbContext, caseTemplateSiteTag));
                dbContext.SaveChanges();
            }
            
        }


        public CaseTemplateSiteTagVersion MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateSiteTag caseTemplateSiteTag)
        {
            CaseTemplateSiteTagVersion caseTemplateSiteTagVersion = new CaseTemplateSiteTagVersion();
            caseTemplateSiteTagVersion.CaseTemplateId = caseTemplateSiteTag.CaseTemplateId;
            caseTemplateSiteTagVersion.SdkSiteTagId = caseTemplateSiteTag.SdkSiteTagId;
            caseTemplateSiteTagVersion.CreatedAt = caseTemplateSiteTag.CreatedAt;
            caseTemplateSiteTagVersion.UpdatedAt = caseTemplateSiteTag.UpdatedAt;
            caseTemplateSiteTagVersion.CreatedByUserId = caseTemplateSiteTag.CreatedByUserId;
            caseTemplateSiteTagVersion.UpdatedByUserId = caseTemplateSiteTag.UpdatedByUserId;
            caseTemplateSiteTagVersion.Version = caseTemplateSiteTag.Version;
            caseTemplateSiteTagVersion.WorkflowState = caseTemplateSiteTag.WorkflowState;
            caseTemplateSiteTagVersion.CaseTemplateSiteTagId = caseTemplateSiteTag.Id;
            
            return caseTemplateSiteTagVersion;

        }
        
    }
}