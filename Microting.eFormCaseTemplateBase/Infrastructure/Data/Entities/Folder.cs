using System.Collections.Generic;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class Folder : PnBase
    {
        public Folder()
        {
            Children = new HashSet<Folder>();

        }

        public int? ParentId { get; set; }

        public virtual Folder Parent { get; set; }

        public virtual ICollection<Folder> Children { get; set; }

        public virtual ICollection<FolderTranslation> FolderTranslations { get; set; }

        public virtual FolderProperty FolderProperty { get; set; }
    }
}