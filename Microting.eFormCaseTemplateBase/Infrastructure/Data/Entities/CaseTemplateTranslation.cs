using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class CaseTemplateTranslation : PnBase
{
    [ForeignKey("CaseTemplate")]
    public int CaseTemplateId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string PdfTitle { get; set; }

    public int LanguageId { get; set; }

}