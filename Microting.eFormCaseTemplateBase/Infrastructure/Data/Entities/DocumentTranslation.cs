using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class DocumentTranslation : PnBase
{
    [ForeignKey("Document")]
    public int DocumentId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string PdfTitle { get; set; }

    public int LanguageId { get; set; }

}