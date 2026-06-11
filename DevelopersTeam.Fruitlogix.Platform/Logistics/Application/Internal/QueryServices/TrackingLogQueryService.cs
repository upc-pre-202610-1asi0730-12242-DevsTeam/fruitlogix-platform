using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.QueryServices;

public class TrackingLogQueryService : ITrackingLogQueryService
{
    private readonly ITrackingLogRepository _trackingLogRepository;

    public TrackingLogQueryService(ITrackingLogRepository trackingLogRepository)
    {
        _trackingLogRepository = trackingLogRepository;
    }

    public async Task<IEnumerable<TrackingLog>> Handle(GetTrackingLogsByDeliveryIdQuery query)
    {
        return await _trackingLogRepository.FindByDeliveryIdAsync(query.DeliveryId);
    }
}