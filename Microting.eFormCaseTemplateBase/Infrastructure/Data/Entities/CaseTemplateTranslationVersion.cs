using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class CaseTemplateTranslationVersion: BaseEntity
{
    [ForeignKey("CaseTemplateTranslation")]
    public int CaseTemplateTranslationId { get; set; }

    public int CaseTemplateId { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public string PdfTitle { get; set; }

}