using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentUploadedData : PnBase
    {
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        [ForeignKey("UploadedDatas")]
        public int UploadedDataId { get; set; }

        public string Title { get; set; }

        public bool Approvable { get; set; }

        public bool RetractIfApproved { get; set; }

        public virtual Document Document { get; set; }

        public virtual UploadedData UploadedData { get; set; }

        public int LanguageId { get; set; }
    }
}