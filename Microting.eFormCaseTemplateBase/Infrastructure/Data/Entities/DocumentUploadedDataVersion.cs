using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentUploadedDataVersion : BaseEntity
    {
        public int DocumentId { get; set; }

        public string Name { get; set; }

        public string File { get; set; }

        public bool Approvable { get; set; }

        public bool RetractIfApproved { get; set; }

        public virtual Document Document { get; set; }

        [ForeignKey("DocumentUploadedDatas")]
        public int DocumentUploadedDataId { get; set; }

        public int LanguageId { get; set; }

        public string Hash { get; set; }

        public string SdkHash { get; set; }

        public string Extension { get; set; }
	}
}