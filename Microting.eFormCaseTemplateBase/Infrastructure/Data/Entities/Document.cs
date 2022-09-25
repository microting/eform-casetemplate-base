using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class Document : PnBase
    {

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public bool Approvable { get; set; }

        public bool RetractIfApproved { get; set; }

        public bool AlwaysShow { get; set; }

        [ForeignKey("Folder")]
        public int FolderId { get; set; }

        public virtual ICollection<DocumentUploadedData> DocumentUploadedDatas { get; set; }

        public virtual ICollection<DocumentTranslation> DocumentTranslations { get; set; }

        public virtual ICollection<DocumentProperty> DocumentProperties { get; set; }
    }
}