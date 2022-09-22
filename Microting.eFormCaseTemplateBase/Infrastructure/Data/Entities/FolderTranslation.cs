using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class FolderTranslation : PnBase
{
    [ForeignKey("Folder")]
    public int FolderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
}