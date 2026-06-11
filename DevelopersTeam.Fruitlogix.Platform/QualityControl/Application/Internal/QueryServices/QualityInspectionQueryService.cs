using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.QueryServices;

public class QualityInspectionQueryService(
    IQualityInspectionRepository qualityInspectionRepository
) : IQualityInspectionQueryService
{
    public async Task<QualityInspection?> Handle(GetQualityInspectionByBatchIdQuery query) =>
        await qualityInspectionRepository.FindByBatchIdAsync(query.BatchId);
}