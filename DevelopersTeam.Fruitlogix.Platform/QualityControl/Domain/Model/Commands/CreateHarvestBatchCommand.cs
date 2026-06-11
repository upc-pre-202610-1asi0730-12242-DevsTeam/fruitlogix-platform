namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

public record CreateHarvestBatchCommand(
    int ProducerId,
    string FruitType,
    double QuantityKg,
    DateOnly HarvestDate
);