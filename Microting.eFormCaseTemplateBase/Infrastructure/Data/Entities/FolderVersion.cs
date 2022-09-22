using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public sealed class FolderVersion : BaseEntity
    {
        public int? ParentId { get; set; }

        [ForeignKey("Folder")]
        public int FolderId { get; set; }
    }
}