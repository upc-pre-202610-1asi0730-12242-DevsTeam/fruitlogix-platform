using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.CommandServices;

public class HarvestBatchCommandService(
    IHarvestBatchRepository harvestBatchRepository,
    IUnitOfWork unitOfWork
) : IHarvestBatchCommandService
{
    public async Task<HarvestBatch> Handle(CreateHarvestBatchCommand command)
    {
        var batch = new HarvestBatch(
            command.ProducerId,
            command.FruitType,
            command.QuantityKg,
            command.HarvestDate
        );

        await harvestBatchRepository.AddAsync(batch);
        await unitOfWork.CompleteAsync();

        return batch;
    }

    public async Task<HarvestBatch?> Handle(UpdateHarvestBatchStatusCommand command)
    {
        var batch = await harvestBatchRepository.FindByIdAsync(command.BatchId);
        if (batch is null) return null;

        batch.UpdateStatus(command.NewStatus);
        harvestBatchRepository.Update(batch);
        await unitOfWork.CompleteAsync();

        return batch;
    }
}