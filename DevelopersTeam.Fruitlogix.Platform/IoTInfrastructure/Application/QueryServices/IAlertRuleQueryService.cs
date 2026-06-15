using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;

public interface IAlertRuleQueryService
{
    Task<IEnumerable<AlertRule>> Handle(GetAllAlertRulesQuery query);
}