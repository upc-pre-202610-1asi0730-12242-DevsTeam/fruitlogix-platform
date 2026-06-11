using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Entities;

public class VisualInspection : IAuditableEntity
{
    public int Id { get; private set; }
    public int QualityInspectionId { get; private set; }

    // AppearanceRating almacenado como int en BD
    public int AppearanceRating { get; private set; }

    // VisualDefects almacenados como columnas bool separadas
    public bool HasStains { get; private set; }
    public bool HasBruises { get; private set; }
    public bool HasDeformations { get; private set; }
    public bool HasRot { get; private set; }

    // WastePercentage almacenado como double en BD
    public double WastePercentage { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public VisualInspection() { }

    public VisualInspection(
        int qualityInspectionId,
        AppearanceRating rating,
        VisualDefects defects,
        WastePercentage wastePercentage)
    {
        QualityInspectionId = qualityInspectionId;
        AppearanceRating    = rating.Value;
        HasStains           = defects.HasStains;
        HasBruises          = defects.HasBruises;
        HasDeformations     = defects.HasDeformations;
        HasRot              = defects.HasRot;
        WastePercentage     = wastePercentage.Value;
    }
}