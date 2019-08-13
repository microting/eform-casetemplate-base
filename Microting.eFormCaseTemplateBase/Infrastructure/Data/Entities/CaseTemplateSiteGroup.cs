using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteGroup : BaseEntity
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
            CaseTemplateSiteGroup caseTemplateSiteGroup =
                dbContext.CaseTemplateSiteGroups.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteGroup == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteGroup.CaseTemplateId = CaseTemplateId;
            caseTemplateSiteGroup.SdkSiteGroupId = SdkSiteGroupId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteGroup.UpdatedAt = DateTime.Now;
                caseTemplateSiteGroup.Version += 1;

                dbContext.CaseTemplateSiteGroupVersions.Add(MapVersions(dbContext, caseTemplateSiteGroup));
                dbContext.SaveChanges();
            }
        }


        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSiteGroup caseTemplateSiteGroup =
                dbContext.CaseTemplateSiteGroups.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSiteGroup == null) 
            {
                throw new NullReferenceException($"Could not find case template site group with id: {Id}");
            }

            caseTemplateSiteGroup.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSiteGroup.UpdatedAt = DateTime.Now;
                caseTemplateSiteGroup.Version += 1;

                dbContext.CaseTemplateSiteGroupVersions.Add(MapVersions(dbContext, caseTemplateSiteGroup));
                dbContext.SaveChanges();
            }
            
        }


        public CaseTemplateSiteGroupVersion MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateSiteGroup caseTemplateSiteGroup)
        {
            CaseTemplateSiteGroupVersion caseTemplateSiteGroupVersion = new CaseTemplateSiteGroupVersion();
            caseTemplateSiteGroupVersion.CaseTemplateId = caseTemplateSiteGroup.CaseTemplateId;
            caseTemplateSiteGroupVersion.SdkSiteGroupId = caseTemplateSiteGroup.SdkSiteGroupId;
            caseTemplateSiteGroupVersion.CreatedAt = caseTemplateSiteGroup.CreatedAt;
            caseTemplateSiteGroupVersion.UpdatedAt = caseTemplateSiteGroup.UpdatedAt;
            caseTemplateSiteGroupVersion.CreatedByUserId = caseTemplateSiteGroup.CreatedByUserId;
            caseTemplateSiteGroupVersion.UpdatedByUserId = caseTemplateSiteGroup.UpdatedByUserId;
            caseTemplateSiteGroupVersion.Version = caseTemplateSiteGroup.Version;
            caseTemplateSiteGroupVersion.WorkflowState = caseTemplateSiteGroup.WorkflowState;
            caseTemplateSiteGroupVersion.CaseTemplateSiteGroupId = caseTemplateSiteGroup.Id;
            
            return caseTemplateSiteGroupVersion;

        }
        
    }
}