using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Entities;

public class PreparationChecklist : IAuditableEntity
{
    public int Id { get; private set; }
    public int QualityInspectionId { get; private set; }

    public bool DryCleaningDone { get; private set; }
    public bool CaliberSortingConfirmed { get; private set; }
    public bool PackagingMaterialInspected { get; private set; }
    public bool FinalBoxSealing { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public PreparationChecklist() { }

    public PreparationChecklist(
        int qualityInspectionId,
        bool dryCleaningDone,
        bool caliberSortingConfirmed,
        bool packagingMaterialInspected,
        bool finalBoxSealing)
    {
        QualityInspectionId          = qualityInspectionId;
        DryCleaningDone              = dryCleaningDone;
        CaliberSortingConfirmed      = caliberSortingConfirmed;
        PackagingMaterialInspected   = packagingMaterialInspected;
        FinalBoxSealing              = finalBoxSealing;
    }
}