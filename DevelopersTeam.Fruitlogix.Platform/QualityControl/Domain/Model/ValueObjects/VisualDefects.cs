namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;

public record VisualDefects(
    bool HasStains,
    bool HasBruises,
    bool HasDeformations,
    bool HasRot
);