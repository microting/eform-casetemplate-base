using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSites : BaseEntity
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
            CaseTemplateSites caseTemplateSites = dbContext.CaseTemplateSites.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSites == null)
            {
                throw new NullReferenceException($"Could not find Case Template Site with id: {Id}");
            }

            caseTemplateSites.CaseTemplateId = CaseTemplateId;
            caseTemplateSites.SdkSiteId = SdkSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSites.UpdatedAt = DateTime.Now;
                caseTemplateSites.Version += 1;

                dbContext.CaseTemplateSiteVersions.Add(MapVersions(dbContext, caseTemplateSites));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateSites caseTemplateSites = dbContext.CaseTemplateSites.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateSites == null)
            {
                throw new NullReferenceException($"Could not find Case Template Site with id: {Id}");
            }
            
            caseTemplateSites.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateSites.UpdatedAt = DateTime.Now;
                caseTemplateSites.Version += 1;

                dbContext.CaseTemplateSiteVersions.Add(MapVersions(dbContext, caseTemplateSites));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateSiteVersions MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateSites caseTemplateSites)
        {
            CaseTemplateSiteVersions caseTemplateSiteVersions = new CaseTemplateSiteVersions();

            caseTemplateSiteVersions.CaseTemplateId = caseTemplateSites.CaseTemplateId;
            caseTemplateSiteVersions.SdkSiteId = caseTemplateSites.SdkSiteId;
            caseTemplateSiteVersions.Version = caseTemplateSites.Version;
            caseTemplateSiteVersions.CreatedAt = caseTemplateSites.CreatedAt;
            caseTemplateSiteVersions.UpdatedAt = caseTemplateSites.UpdatedAt;
            caseTemplateSiteVersions.CreatedByUserId = caseTemplateSites.CreatedByUserId;
            caseTemplateSiteVersions.UpdatedByUserId = caseTemplateSites.UpdatedByUserId;
            caseTemplateSiteVersions.WorkflowState = caseTemplateSites.WorkflowState;
            
            caseTemplateSiteVersions.CaseTemplateSiteId = caseTemplateSites.Id;

            return caseTemplateSiteVersions;
        }
    }
}