using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Infrastructure.Persistence.EFC.Repositories;

public class HarvestBatchRepository(AppDbContext context)
    : BaseRepository<HarvestBatch>(context), IHarvestBatchRepository
{
}