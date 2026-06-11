using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;

public interface IHarvestBatchQueryService
{
    Task<IEnumerable<HarvestBatch>> Handle(GetAllHarvestBatchesQuery query);
}