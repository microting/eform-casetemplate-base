using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentVersion : BaseEntity
    {

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public string PdfTitle { get; set; }

        public bool Approvable { get; set; }

        public bool RetractIfApproved { get; set; }

        public bool AlwaysShow { get; set; }

        public int DescriptionFolderId { get; set; }

        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        public int FolderId { get; set; }
    }
}