using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSite : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteId { get; set; }


        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.CaseTemplateSites.Add(this);
            dbContext.SaveChanges();

            dbContext.CaseTemplateSiteVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSite caseTemplateSite = dbContext.CaseTemplateSites.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSite == null)
            {
                throw new NullReferenceException($"Could not find Case Template Site with id: {Id}");
            }

            caseTemplateSite.CaseTemplateId = CaseTemplateId;
            caseTemplateSite.SdkSiteId = SdkSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSite.UpdatedAt = DateTime.Now;
                caseTemplateSite.Version += 1;

                dbContext.CaseTemplateSiteVersions.Add(MapVersions(dbContext, caseTemplateSite));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSite caseTemplateSite = dbContext.CaseTemplateSites.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSite == null)
            {
                throw new NullReferenceException($"Could not find Case Template Site with id: {Id}");
            }
            
            caseTemplateSite.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSite.UpdatedAt = DateTime.Now;
                caseTemplateSite.Version += 1;

                dbContext.CaseTemplateSiteVersions.Add(MapVersions(dbContext, caseTemplateSite));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateSiteVersion MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateSite caseTemplateSite)
        {
            CaseTemplateSiteVersion caseTemplateSiteVersion = new CaseTemplateSiteVersion();

            caseTemplateSiteVersion.CaseTemplateId = caseTemplateSite.CaseTemplateId;
            caseTemplateSiteVersion.SdkSiteId = caseTemplateSite.SdkSiteId;
            caseTemplateSiteVersion.Version = caseTemplateSite.Version;
            caseTemplateSiteVersion.CreatedAt = caseTemplateSite.CreatedAt;
            caseTemplateSiteVersion.UpdatedAt = caseTemplateSite.UpdatedAt;
            caseTemplateSiteVersion.CreatedByUserId = caseTemplateSite.CreatedByUserId;
            caseTemplateSiteVersion.UpdatedByUserId = caseTemplateSite.UpdatedByUserId;
            caseTemplateSiteVersion.WorkflowState = caseTemplateSite.WorkflowState;
            
            caseTemplateSiteVersion.CaseTemplateSiteId = caseTemplateSite.Id;

            return caseTemplateSiteVersion;
        }
    }
}