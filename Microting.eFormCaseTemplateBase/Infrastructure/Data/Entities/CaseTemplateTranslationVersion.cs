using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;

public class CaseTemplateTranslationVersion: BaseEntity
{
    [ForeignKey("CaseTemplateTranslation")]
    public int CaseTemplateTranslationId { get; set; }

}