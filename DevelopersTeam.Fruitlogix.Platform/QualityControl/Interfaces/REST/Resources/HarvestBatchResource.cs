namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

public record HarvestBatchResource(
    int Id,
    int ProducerId,
    string FruitType,
    double QuantityKg,
    DateOnly HarvestDate,
    string Status
);