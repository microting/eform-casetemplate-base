using System.Collections.Generic;
using Microting.eForm.Infrastructure.Data.Entities;
using BaseEntity = Microting.eFormApi.BasePn.Infrastructure.Database.Base.BaseEntity;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DescriptionFolders : BaseEntity
    {
        public DescriptionFolders()
        {            
            Children = new HashSet<DescriptionFolders>();
            
        }
        
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        
        public int SdkFolderId { get; set; }

        public virtual DescriptionFolders Parent { get; set; }

        public virtual ICollection<DescriptionFolders> Children { get; set; }
    }
}