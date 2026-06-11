using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;

public interface ITrackingLogQueryService
{
    Task<IEnumerable<TrackingLog>> Handle(GetTrackingLogsByDeliveryIdQuery query);
}