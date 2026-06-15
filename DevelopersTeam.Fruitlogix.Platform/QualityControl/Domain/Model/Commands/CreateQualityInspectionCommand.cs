namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

public record CreateQualityInspectionCommand(
    int BatchId,
    string? Notes,
    
    // Visual
    int AppearanceRating,
    bool HasStains,
    bool HasBruises,
    bool HasDeformations,
    bool HasRot,
    double WastePercentage,
    
    // Technical
    double TemperatureCelsius,
    double HumidityPercent,
    double Ph,
    double BrixDegrees,
    
    // Checklist
    bool DryCleaningDone,
    bool CaliberSortingConfirmed,
    bool PackagingMaterialInspected,
    bool FinalBoxSealing
);