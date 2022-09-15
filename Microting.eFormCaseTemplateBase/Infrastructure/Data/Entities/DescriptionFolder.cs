using System;
using System.Collections.Generic;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using BaseEntity = Microting.eFormApi.BasePn.Infrastructure.Database.Base.BaseEntity;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class DescriptionFolder : PnBase
    {
        public DescriptionFolder()
        {
            Children = new HashSet<DescriptionFolder>();

        }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int SdkFolderId { get; set; }

        public virtual DescriptionFolder Parent { get; set; }

        public virtual ICollection<DescriptionFolder> Children { get; set; }
    }
}