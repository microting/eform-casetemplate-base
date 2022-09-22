using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class FolderProperty : PnBase
{
    [ForeignKey("Folder")]
    public int FolderId { get; set; }
    public int PropertyId { get; set; }
    public int SdkFolderId { get; set; }
}