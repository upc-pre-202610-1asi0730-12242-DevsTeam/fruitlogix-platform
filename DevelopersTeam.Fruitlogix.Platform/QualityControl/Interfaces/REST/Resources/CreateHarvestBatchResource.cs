namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

public record CreateHarvestBatchResource(
    int ProducerId,
    string FruitType,
    double QuantityKg,
    DateOnly HarvestDate
);