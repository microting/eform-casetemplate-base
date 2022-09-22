using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentSiteTagVersion : BaseEntity
    {
        public int DocumentId { get; set; }

        public int SdkSiteTagId { get; set; }

        [ForeignKey("DocumentSiteTags")]
        public int DocumentSiteTagId { get; set; }
    }
}