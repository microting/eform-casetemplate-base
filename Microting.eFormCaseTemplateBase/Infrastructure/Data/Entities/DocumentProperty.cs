using System.ComponentModel.DataAnnotations.Schema;
using Microting.eForm.Infrastructure.Data.Entities;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class DocumentProperty : PnBase
{
    [ForeignKey("CaseTemplates")]
    public int CaseTemplateId { get; set; }

    public int PropertyId { get; set; }

}