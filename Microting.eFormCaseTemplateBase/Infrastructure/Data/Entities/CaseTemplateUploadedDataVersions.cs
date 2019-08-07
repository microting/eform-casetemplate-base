using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateUploadedDataVersions : BaseEntity
    {
        public int CaseTemplateId { get; set; }
        
        public int UploadedDataId { get; set; }
        
        public string Title { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public virtual CaseTemplates CaseTemplates { get; set; }
        
        public virtual UploadedDatas UploadedDatas { get; set; }
        
        [ForeignKey("CaseTemplateUploadedDatas")]
        public int CaseTemplateUploadedDataId { get; set; }
    }
}