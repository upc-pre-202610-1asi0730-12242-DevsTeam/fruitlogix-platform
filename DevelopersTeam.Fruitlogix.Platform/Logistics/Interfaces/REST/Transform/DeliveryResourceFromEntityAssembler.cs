using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;

public static class DeliveryResourceFromEntityAssembler
{
    public static DeliveryResource ToResourceFromEntity(Delivery entity) =>
        new(
            entity.Id,
            entity.OrderId,
            entity.Driver.Name,
            entity.Driver.Phone,
            entity.Vehicle.Plate,
            entity.Vehicle.Type,
            entity.Route.Origin,
            entity.Route.Destination,
            entity.Route.DistanceKm,
            entity.EstimatedTimeOfArrival,
            entity.CurrentStatus.ToString()
        );
}