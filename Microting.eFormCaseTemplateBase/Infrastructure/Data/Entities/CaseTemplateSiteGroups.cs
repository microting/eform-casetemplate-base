using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteGroups : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteGroupId { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            dbContext.CaseTemplateSiteGroups.Add(this);
            dbContext.SaveChanges();
            dbContext.CaseTemplateSiteGroupVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSiteGroups caseTemplateSiteGroups =
                dbContext.CaseTemplateSiteGroups.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteGroups == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteGroups.CaseTemplateId = CaseTemplateId;
            caseTemplateSiteGroups.SdkSiteGroupId = SdkSiteGroupId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteGroups.UpdatedAt = DateTime.Now;
                caseTemplateSiteGroups.Version += 1;

                dbContext.CaseTemplateSiteGroupVersions.Add(MapVersions(dbContext, caseTemplateSiteGroups));
                dbContext.SaveChanges();
            }
        }


        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSiteGroups caseTemplateSiteGroups =
                dbContext.CaseTemplateSiteGroups.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteGroups == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteGroups.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteGroups.UpdatedAt = DateTime.Now;
                caseTemplateSiteGroups.Version += 1;

                dbContext.CaseTemplateSiteGroupVersions.Add(MapVersions(dbContext, caseTemplateSiteGroups));
                dbContext.SaveChanges();
            }
            
        }


        public CaseTemplateSiteGroupVersions MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateSiteGroups caseTemplateSiteGroups)
        {
            CaseTemplateSiteGroupVersions caseTemplateSiteGroupVersions = new CaseTemplateSiteGroupVersions();
            caseTemplateSiteGroupVersions.CaseTemplateId = caseTemplateSiteGroups.CaseTemplateId;
            caseTemplateSiteGroupVersions.SdkSiteGroupId = caseTemplateSiteGroups.SdkSiteGroupId;
            caseTemplateSiteGroupVersions.CreatedAt = caseTemplateSiteGroups.CreatedAt;
            caseTemplateSiteGroupVersions.UpdatedAt = caseTemplateSiteGroups.UpdatedAt;
            caseTemplateSiteGroupVersions.CreatedByUserId = caseTemplateSiteGroups.CreatedByUserId;
            caseTemplateSiteGroupVersions.UpdatedByUserId = caseTemplateSiteGroups.UpdatedByUserId;
            caseTemplateSiteGroupVersions.Version = caseTemplateSiteGroups.Version;
            caseTemplateSiteGroupVersions.WorkflowState = caseTemplateSiteGroups.WorkflowState;
            caseTemplateSiteGroupVersions.CaseTemplateSiteGroupId = caseTemplateSiteGroups.Id;
            
            return caseTemplateSiteGroupVersions;

        }
        
    }
}