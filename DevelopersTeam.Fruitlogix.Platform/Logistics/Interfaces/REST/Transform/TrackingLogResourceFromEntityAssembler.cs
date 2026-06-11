using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;

public static class TrackingLogResourceFromEntityAssembler
{
    public static TrackingLogResource ToResourceFromEntity(TrackingLog entity) =>
        new(
            entity.Id,
            entity.DeliveryId,
            entity.Timestamp,
            entity.Location.Latitude,
            entity.Location.Longitude,
            entity.Temperature,
            entity.Humidity
        );
}