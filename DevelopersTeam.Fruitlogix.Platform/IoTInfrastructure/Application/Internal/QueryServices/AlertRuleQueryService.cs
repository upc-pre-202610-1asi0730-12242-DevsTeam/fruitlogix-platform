using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.QueryServices;

public class AlertRuleQueryService(IAlertRuleRepository repository)
    : IAlertRuleQueryService
{
    public async Task<IEnumerable<AlertRule>> Handle(GetAllAlertRulesQuery query)
        => await repository.ListAsync();
}