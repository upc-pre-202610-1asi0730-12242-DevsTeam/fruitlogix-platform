using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;

public interface IQualityInspectionRepository : IBaseRepository<QualityInspection>
{
    Task<QualityInspection?> FindByBatchIdAsync(int batchId);
}