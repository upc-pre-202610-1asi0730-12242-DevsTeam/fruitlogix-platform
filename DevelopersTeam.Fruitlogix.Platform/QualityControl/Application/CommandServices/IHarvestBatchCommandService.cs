using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;

public interface IHarvestBatchCommandService
{
    Task<HarvestBatch> Handle(CreateHarvestBatchCommand command);
}