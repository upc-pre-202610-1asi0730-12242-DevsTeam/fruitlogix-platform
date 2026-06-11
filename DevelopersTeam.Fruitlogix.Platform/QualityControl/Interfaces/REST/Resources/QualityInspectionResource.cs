namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

public record VisualInspectionResource(
    int AppearanceRating,
    bool HasStains,
    bool HasBruises,
    bool HasDeformations,
    bool HasRot,
    double WastePercentage
);

public record TechnicalParametersResource(
    double TemperatureCelsius,
    double HumidityPercent,
    double Ph,
    double BrixDegrees
);

public record PreparationChecklistResource(
    bool DryCleaningDone,
    bool CaliberSortingConfirmed,
    bool PackagingMaterialInspected,
    bool FinalBoxSealing
);

public record QualityInspectionResource(
    int Id,
    int BatchId,
    string? Notes,
    VisualInspectionResource VisualInspection,
    TechnicalParametersResource TechnicalParameters,
    PreparationChecklistResource PreparationChecklist
);