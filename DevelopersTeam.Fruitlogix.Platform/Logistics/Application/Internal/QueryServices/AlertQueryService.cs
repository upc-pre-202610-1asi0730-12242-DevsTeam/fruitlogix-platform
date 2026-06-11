using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.QueryServices;

public class AlertQueryService : IAlertQueryService
{
    private readonly IAlertRepository _alertRepository;

    public AlertQueryService(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
    }

    public async Task<IEnumerable<Alert>> Handle(GetAllActiveAlertsQuery query)
    {
        return await _alertRepository.FindActiveAlertsAsync();
    }
}