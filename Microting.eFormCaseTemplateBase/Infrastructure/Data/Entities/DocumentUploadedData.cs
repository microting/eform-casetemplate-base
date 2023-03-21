using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentUploadedData : PnBase
    {
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        public string Name { get; set; }

        public string File { get; set; }

        public bool Approvable { get; set; }

        public bool RetractIfApproved { get; set; }

        public virtual Document Document { get; set; }

        public int LanguageId { get; set; }

        public string Hash { get; set; }

        public string SdkHash { get; set; }

        public string Extension { get; set; }
	}
}