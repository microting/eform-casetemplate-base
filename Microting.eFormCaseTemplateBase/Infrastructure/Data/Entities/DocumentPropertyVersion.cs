using System.ComponentModel.DataAnnotations.Schema;
using Microting.eForm.Infrastructure.Data.Entities;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class DocumentPropertyVersion : BaseEntity
{
    public int DocumentId { get; set; }

    public int PropertyId { get; set; }

    public int DocumentPropertyId { get; set; }

}