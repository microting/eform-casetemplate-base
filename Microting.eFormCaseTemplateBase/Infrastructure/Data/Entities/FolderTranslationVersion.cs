using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class FolderTranslationVersion : BaseEntity
{
    [ForeignKey("FolderTranslation")]
    public int FolderTranslationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
}