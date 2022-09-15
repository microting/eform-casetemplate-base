using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class CaseTemplateTranslation : BaseEntity
{
    public string Title { get; set; }

    public string Body { get; set; }

    public string PdfTitle { get; set; }

}