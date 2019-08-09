using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;


namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public partial class Case : BaseEntity
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
        
        public virtual CaseTemplate CaseTemplate { get; set; }
        
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

            dbContext.CaseVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            Case @case = dbContext.Cases.FirstOrDefault(x => x.Id == Id);

            if (@case == null)
            {
                throw new NullReferenceException($"Could not find case with id {Id}");
            }

            @case.Status = Status;
            @case.Type = Type;
            @case.CaseTemplate = CaseTemplate;
            @case.DoneAt = DoneAt;
            @case.eFormId = eFormId;
            @case.SiteId = SiteId;
            @case.UnitId = UnitId;
            @case.WorkerId = WorkerId;
            @case.CaseTemplateId = CaseTemplateId;
            @case.FetchedByTablet = FetchedByTablet;
            @case.FetchedByTabletAt = FetchedByTabletAt;
            @case.ReceiptRetrievedFromUser = ReceiptRetrievedFromUser;
            @case.ReceiptRetrievedFromUserAt = ReceiptRetrievedFromUserAt;

            if (dbContext.ChangeTracker.HasChanges())
            {
                @case.UpdatedAt = DateTime.Now;
                @case.Version += 1;

                dbContext.CaseVersions.Add(MapVersions(dbContext, @case));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            Case @case = dbContext.Cases.FirstOrDefault(x => x.Id == Id);

            if (@case == null)
            {
                throw new NullReferenceException($"Could not find case with id {Id}");
            }

            @case.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                @case.UpdatedAt = DateTime.Now;
                @case.Version += 1;

                dbContext.CaseVersions.Add(MapVersions(dbContext, @case));
                dbContext.SaveChanges();
            }
        }


        public CaseVersion MapVersions(CaseTemplatePnDbContext dbContext, Case @case)
        {
            CaseVersion caseVersion = new CaseVersion();
            caseVersion.Status = @case.Status;
            caseVersion.Type = @case.Type;
            caseVersion.CaseTemplate = @case.CaseTemplate;
            caseVersion.DoneAt = @case.DoneAt;
            caseVersion.eFormId = @case.eFormId;
            caseVersion.SiteId = @case.SiteId;
            caseVersion.UnitId = @case.UnitId;
            caseVersion.WorkerId = @case.WorkerId;
            caseVersion.CaseTemplateId = @case.CaseTemplateId;
            caseVersion.FetchedByTablet = @case.FetchedByTablet;
            caseVersion.FetchedByTabletAt = @case.FetchedByTabletAt;
            caseVersion.ReceiptRetrievedFromUser = @case.ReceiptRetrievedFromUser;
            caseVersion.ReceiptRetrievedFromUserAt = @case.ReceiptRetrievedFromUserAt;
            caseVersion.Version = @case.Version;
            caseVersion.CreatedAt = @case.CreatedAt;
            caseVersion.UpdatedAt = @case.UpdatedAt;
            caseVersion.WorkflowState = @case.WorkflowState;
            
            caseVersion.CaseId = @case.Id;
            return caseVersion;
        }
    }
}