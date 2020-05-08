using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteTagVersion : BaseEntity
    {
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteTagId { get; set; }
        
        [ForeignKey("CaseTemplateSiteTags")]
        public int CaseTemplateSiteTagId { get; set; }
    }
}