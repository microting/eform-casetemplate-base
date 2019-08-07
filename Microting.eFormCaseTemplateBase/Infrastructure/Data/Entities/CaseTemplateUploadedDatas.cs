using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateUploadedDatas : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        [ForeignKey("UploadedDatas")]
        public int UploadedDataId { get; set; }
        
        public string Title { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public virtual CaseTemplates CaseTemplates { get; set; }
        
        public virtual UploadedDatas UploadedDatas { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.CaseTemplateUploadedDatas.Add(this);
            dbContext.SaveChanges();

            dbContext.CaseTemplateUploadedDataVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateUploadedDatas caseTemplateUploadedDatas =
                dbContext.CaseTemplateUploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateUploadedDatas == null)
            {
                throw new NullReferenceException($"Could not find Case Template Uploaded Data with id {Id}");
            }

            caseTemplateUploadedDatas.Approvable = Approvable;
            caseTemplateUploadedDatas.Title = Title;
            caseTemplateUploadedDatas.CaseTemplates = CaseTemplates;
            caseTemplateUploadedDatas.UploadedDatas = UploadedDatas;
            caseTemplateUploadedDatas.CaseTemplateId = CaseTemplateId;
            caseTemplateUploadedDatas.RetractIfApproved = RetractIfApproved;
            caseTemplateUploadedDatas.UploadedDataId = UploadedDataId;
           
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateUploadedDatas.UpdatedAt = DateTime.Now;
                caseTemplateUploadedDatas.Version += 1;

                dbContext.CaseTemplateUploadedDataVersions.Add(MapVersions(dbContext, caseTemplateUploadedDatas));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateUploadedDatas caseTemplateUploadedDatas =
                dbContext.CaseTemplateUploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateUploadedDatas == null)
            {
                throw new NullReferenceException($"Could not find Case Template Uploaded Data with id {Id}");
            }

            caseTemplateUploadedDatas.WorkflowState = Constants.WorkflowStates.Removed;
           
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateUploadedDatas.UpdatedAt = DateTime.Now;
                caseTemplateUploadedDatas.Version += 1;

                dbContext.CaseTemplateUploadedDataVersions.Add(MapVersions(dbContext, caseTemplateUploadedDatas));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateUploadedDataVersions MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateUploadedDatas caseTemplateUploadedDatas)
        {
            CaseTemplateUploadedDataVersions caseTemplateUploadedDataVersions = new CaseTemplateUploadedDataVersions();

            caseTemplateUploadedDataVersions.Approvable = caseTemplateUploadedDatas.Approvable;
            caseTemplateUploadedDataVersions.Title = caseTemplateUploadedDatas.Title;
            caseTemplateUploadedDataVersions.CaseTemplates = caseTemplateUploadedDatas.CaseTemplates;
            caseTemplateUploadedDataVersions.UploadedDatas = caseTemplateUploadedDatas.UploadedDatas;
            caseTemplateUploadedDataVersions.CaseTemplateId = caseTemplateUploadedDatas.CaseTemplateId;
            caseTemplateUploadedDataVersions.RetractIfApproved = caseTemplateUploadedDatas.RetractIfApproved;
            caseTemplateUploadedDataVersions.UploadedDataId = caseTemplateUploadedDatas.UploadedDataId;
            caseTemplateUploadedDataVersions.Version = caseTemplateUploadedDatas.Version;
            caseTemplateUploadedDataVersions.CreatedAt = caseTemplateUploadedDatas.CreatedAt;
            caseTemplateUploadedDataVersions.UpdatedAt = caseTemplateUploadedDatas.UpdatedAt;
            caseTemplateUploadedDataVersions.CreatedByUserId = caseTemplateUploadedDatas.CreatedByUserId;
            caseTemplateUploadedDataVersions.UpdatedByUserId = caseTemplateUploadedDatas.UpdatedByUserId;
            caseTemplateUploadedDataVersions.WorkflowState = caseTemplateUploadedDatas.WorkflowState;

            caseTemplateUploadedDataVersions.CaseTemplateUploadedDataId = caseTemplateUploadedDatas.Id;

            return caseTemplateUploadedDataVersions;
        }
    }
}