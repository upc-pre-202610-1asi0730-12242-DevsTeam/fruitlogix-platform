namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

public record CreateQualityInspectionResource(
    int BatchId,
    string? Notes,
    int AppearanceRating,
    bool HasStains,
    bool HasBruises,
    bool HasDeformations,
    bool HasRot,
    double WastePercentage,
    double TemperatureCelsius,
    double HumidityPercent,
    double Ph,
    double BrixDegrees,
    bool DryCleaningDone,
    bool CaliberSortingConfirmed,
    bool PackagingMaterialInspected,
    bool FinalBoxSealing
);