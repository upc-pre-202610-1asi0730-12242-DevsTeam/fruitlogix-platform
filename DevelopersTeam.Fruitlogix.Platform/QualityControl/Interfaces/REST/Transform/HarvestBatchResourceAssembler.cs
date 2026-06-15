using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;

public static class HarvestBatchResourceAssembler
{
    public static CreateHarvestBatchCommand ToCommandFromResource(CreateHarvestBatchResource resource) =>
        new(
            resource.ProducerId,
            resource.FruitType,
            resource.QuantityKg,
            resource.HarvestDate
        );

    public static HarvestBatchResource ToResourceFromEntity(HarvestBatch entity) =>
        new(
            entity.Id,
            entity.ProducerId,
            entity.FruitType,
            entity.QuantityKg,
            entity.HarvestDate,
            entity.Status.ToString()
        );
    public static UpdateHarvestBatchStatusCommand ToCommandFromResource(
        int batchId, UpdateHarvestBatchStatusResource resource)
    {
        if (!Enum.TryParse<BatchStatus>(resource.Status, ignoreCase: true, out var status))
            throw new ArgumentException($"Invalid status value: '{resource.Status}'.");

        return new UpdateHarvestBatchStatusCommand(batchId, status);
    }
    
}