using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateUploadedData : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        [ForeignKey("UploadedDatas")]
        public int UploadedDataId { get; set; }
        
        public string Title { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public virtual CaseTemplate CaseTemplate { get; set; }
        
        public virtual UploadedData UploadedData { get; set; }

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
            CaseTemplateUploadedData caseTemplateUploadedData =
                dbContext.CaseTemplateUploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateUploadedData == null)
            {
                throw new NullReferenceException($"Could not find Case Template Uploaded Data with id {Id}");
            }

            caseTemplateUploadedData.Approvable = Approvable;
            caseTemplateUploadedData.Title = Title;
            caseTemplateUploadedData.CaseTemplate = CaseTemplate;
            caseTemplateUploadedData.UploadedData = UploadedData;
            caseTemplateUploadedData.CaseTemplateId = CaseTemplateId;
            caseTemplateUploadedData.RetractIfApproved = RetractIfApproved;
            caseTemplateUploadedData.UploadedDataId = UploadedDataId;
           
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateUploadedData.UpdatedAt = DateTime.Now;
                caseTemplateUploadedData.Version += 1;

                dbContext.CaseTemplateUploadedDataVersions.Add(MapVersions(dbContext, caseTemplateUploadedData));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            CaseTemplateUploadedData caseTemplateUploadedData =
                dbContext.CaseTemplateUploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (caseTemplateUploadedData == null)
            {
                throw new NullReferenceException($"Could not find Case Template Uploaded Data with id {Id}");
            }

            caseTemplateUploadedData.WorkflowState = Constants.WorkflowStates.Removed;
           
            if (dbContext.ChangeTracker.HasChanges())
            {
                caseTemplateUploadedData.UpdatedAt = DateTime.Now;
                caseTemplateUploadedData.Version += 1;

                dbContext.CaseTemplateUploadedDataVersions.Add(MapVersions(dbContext, caseTemplateUploadedData));
                dbContext.SaveChanges();
            }
        }

        public CaseTemplateUploadedDataVersion MapVersions(CaseTemplatePnDbContext dbContext,
            CaseTemplateUploadedData caseTemplateUploadedData)
        {
            CaseTemplateUploadedDataVersion caseTemplateUploadedDataVersion = new CaseTemplateUploadedDataVersion();

            caseTemplateUploadedDataVersion.Approvable = caseTemplateUploadedData.Approvable;
            caseTemplateUploadedDataVersion.Title = caseTemplateUploadedData.Title;
            caseTemplateUploadedDataVersion.CaseTemplate = caseTemplateUploadedData.CaseTemplate;
            caseTemplateUploadedDataVersion.UploadedData = caseTemplateUploadedData.UploadedData;
            caseTemplateUploadedDataVersion.CaseTemplateId = caseTemplateUploadedData.CaseTemplateId;
            caseTemplateUploadedDataVersion.RetractIfApproved = caseTemplateUploadedData.RetractIfApproved;
            caseTemplateUploadedDataVersion.UploadedDataId = caseTemplateUploadedData.UploadedDataId;
            caseTemplateUploadedDataVersion.Version = caseTemplateUploadedData.Version;
            caseTemplateUploadedDataVersion.CreatedAt = caseTemplateUploadedData.CreatedAt;
            caseTemplateUploadedDataVersion.UpdatedAt = caseTemplateUploadedData.UpdatedAt;
            caseTemplateUploadedDataVersion.CreatedByUserId = caseTemplateUploadedData.CreatedByUserId;
            caseTemplateUploadedDataVersion.UpdatedByUserId = caseTemplateUploadedData.UpdatedByUserId;
            caseTemplateUploadedDataVersion.WorkflowState = caseTemplateUploadedData.WorkflowState;

            caseTemplateUploadedDataVersion.CaseTemplateUploadedDataId = caseTemplateUploadedData.Id;

            return caseTemplateUploadedDataVersion;
        }
    }
}