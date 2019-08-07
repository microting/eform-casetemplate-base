using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplates : BaseEntity
    {
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public DateTime StartAt { get; set; }
        
        public DateTime EndAt { get; set; }
        
        public string PdfTitle { get; set; }
        
        public bool Approvable { get; set; }
        
        public bool RetractIfApproved { get; set; }
        
        public bool AlwaysShow { get; set; }
        
        [ForeignKey("DescriptionFolders")]
        public int DescriptionFolderId { get; set; }
        
        public virtual ICollection<CaseTemplateUploadedDatas> CaseTemplateUploadedDatas { get; set; }
    }
}