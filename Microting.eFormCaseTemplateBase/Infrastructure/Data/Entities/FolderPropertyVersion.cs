using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class FolderPropertyVersion : BaseEntity
{
    [ForeignKey("FolderProperty")]
    public int FolderPropertyId { get; set; }
    public int FolderId { get; set; }
    public int PropertyId { get; set; }
    public int SdkFolderId { get; set; }
}