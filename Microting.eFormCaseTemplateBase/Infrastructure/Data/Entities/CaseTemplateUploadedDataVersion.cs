using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateUploadedDataVersion : BaseEntity
    {
        public int CaseTemplateId { get; set; }
        
        public int UploadedDataId { get; set; }
        
        public string Title { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public virtual CaseTemplate CaseTemplate { get; set; }
        
        public virtual UploadedData UploadedData { get; set; }
        
        [ForeignKey("CaseTemplateUploadedDatas")]
        public int CaseTemplateUploadedDataId { get; set; }
    }
}