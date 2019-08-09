using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteVersion : BaseEntity
    {
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteId { get; set; }
        
        [ForeignKey("CaseTemplateSites")]
        public int CaseTemplateSiteId { get; set; }
    }
}