using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSites : BaseEntity
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }
        
        public int SdkSiteId { get; set; }
    }
}