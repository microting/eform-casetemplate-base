using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class CaseTemplateSite : PnBase
    {
        [ForeignKey("CaseTemplates")]
        public int CaseTemplateId { get; set; }

        public int SdkSiteId { get; set; }

        public int SdkCaseId { get; set; }
    }
}