using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public sealed class DescriptionFolderVersion : BaseEntity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int SdkFolderId { get; set; }

        [ForeignKey("DescriptionFolders")]
        public int DescriptionFolderId { get; set; }
    }
}