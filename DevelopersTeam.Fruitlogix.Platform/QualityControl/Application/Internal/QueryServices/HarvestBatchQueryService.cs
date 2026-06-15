using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.QueryServices;

public class HarvestBatchQueryService(
    IHarvestBatchRepository harvestBatchRepository
) : IHarvestBatchQueryService
{
    public async Task<IEnumerable<HarvestBatch>> Handle(GetAllHarvestBatchesQuery query) =>
        await harvestBatchRepository.ListAsync();
}