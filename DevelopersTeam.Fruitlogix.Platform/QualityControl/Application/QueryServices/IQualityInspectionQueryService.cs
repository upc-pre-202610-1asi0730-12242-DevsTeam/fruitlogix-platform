using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;

public interface IQualityInspectionQueryService
{
    Task<QualityInspection?> Handle(GetQualityInspectionByBatchIdQuery query);
}