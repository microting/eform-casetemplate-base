using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSiteGroupVersions : BaseEntity
    {
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteGroupId { get; set; }
        
        [ForeignKey("CaseTemplateSiteGroups")]
        public int CaseTemplateSiteGroupId { get; set; }
    }
}