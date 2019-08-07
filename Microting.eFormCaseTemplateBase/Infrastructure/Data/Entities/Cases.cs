using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;


namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public partial class Cases : BaseEntity
    {
        public int? Status { get; set; }
        
        public DateTime? DoneAt { get; set; }

        public int? SiteId { get; set; }

        public int? UnitId { get; set; }

        public int? WorkerId { get; set; }
        
        public int? eFormId { get; set; }

        [StringLength(255)]
        public string Type { get; set; }
        
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        public virtual CaseTemplates CaseTemplate { get; set; }
        
        public bool FetchedByTablet { get; set; }
        
        public DateTime FetchedByTabletAt { get; set; }
        
        public bool ReceiptRetrievedFromUser { get; set; }
        
        public DateTime ReceiptRetrievedFromUserAt { get; set; }

        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.Cases.Add(this);
            dbContext.SaveChanges();

            dbContext.CaseVersionses.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            Cases cases = dbContext.Cases.FirstOrDefault(x => x.Id == Id);

            if (cases == null)
            {
                throw new NullReferenceException($"Could not find case with id {Id}");
            }

            cases.Status = Status;
            cases.Type = Type;
            cases.CaseTemplate = CaseTemplate;
            cases.DoneAt = DoneAt;
            cases.eFormId = eFormId;
            cases.SiteId = SiteId;
            cases.UnitId = UnitId;
            cases.WorkerId = WorkerId;
            cases.CaseTemplateId = CaseTemplateId;
            cases.FetchedByTablet = FetchedByTablet;
            cases.FetchedByTabletAt = FetchedByTabletAt;
            cases.ReceiptRetrievedFromUser = ReceiptRetrievedFromUser;
            cases.ReceiptRetrievedFromUserAt = ReceiptRetrievedFromUserAt;

            if (dbContext.ChangeTracker.HasChanges())
            {
                cases.UpdatedAt = DateTime.Now;
                cases.Version += 1;

                dbContext.CaseVersionses.Add(MapVersions(dbContext, cases));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            Cases cases = dbContext.Cases.FirstOrDefault(x => x.Id == Id);

            if (cases == null)
            {
                throw new NullReferenceException($"Could not find case with id {Id}");
            }

            cases.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                cases.UpdatedAt = DateTime.Now;
                cases.Version += 1;

                dbContext.CaseVersionses.Add(MapVersions(dbContext, cases));
                dbContext.SaveChanges();
            }
        }


        public CaseVersions MapVersions(CaseTemplatePnDbContext dbContext, Cases cases)
        {
            CaseVersions caseVersions = new CaseVersions();
            caseVersions.Status = cases.Status;
            caseVersions.Type = cases.Type;
            caseVersions.CaseTemplate = cases.CaseTemplate;
            caseVersions.DoneAt = cases.DoneAt;
            caseVersions.eFormId = cases.eFormId;
            caseVersions.SiteId = cases.SiteId;
            caseVersions.UnitId = cases.UnitId;
            caseVersions.WorkerId = cases.WorkerId;
            caseVersions.CaseTemplateId = cases.CaseTemplateId;
            caseVersions.FetchedByTablet = cases.FetchedByTablet;
            caseVersions.FetchedByTabletAt = cases.FetchedByTabletAt;
            caseVersions.ReceiptRetrievedFromUser = cases.ReceiptRetrievedFromUser;
            caseVersions.ReceiptRetrievedFromUserAt = cases.ReceiptRetrievedFromUserAt;
            caseVersions.Version = cases.Version;
            caseVersions.CreatedAt = cases.CreatedAt;
            caseVersions.UpdatedAt = cases.UpdatedAt;
            caseVersions.WorkflowState = cases.WorkflowState;
            
            caseVersions.CaseId = cases.Id;
            return caseVersions;
        }
    }
}