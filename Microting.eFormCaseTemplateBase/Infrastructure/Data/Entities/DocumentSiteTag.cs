using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DocumentSiteTag : PnBase
    {
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        public int SdkSiteTagId { get; set; }
    }
}