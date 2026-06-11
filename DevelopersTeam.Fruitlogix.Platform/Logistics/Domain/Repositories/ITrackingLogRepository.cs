using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;

public interface ITrackingLogRepository : IBaseRepository<TrackingLog>
{
    Task<IEnumerable<TrackingLog>> FindByDeliveryIdAsync(int deliveryId);
}