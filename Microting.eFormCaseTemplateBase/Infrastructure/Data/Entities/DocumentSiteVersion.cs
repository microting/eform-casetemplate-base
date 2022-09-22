using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentSiteVersion : BaseEntity
    {
        public int DocumentId { get; set; }

        public int SdkSiteId { get; set; }

        public int SdkCaseId { get; set; }

        [ForeignKey("DocumentSites")]
        public int DocumentSiteId { get; set; }
    }
}