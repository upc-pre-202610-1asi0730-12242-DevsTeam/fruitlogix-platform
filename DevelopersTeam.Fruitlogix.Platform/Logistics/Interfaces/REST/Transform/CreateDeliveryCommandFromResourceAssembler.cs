using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;

public static class CreateDeliveryCommandFromResourceAssembler
{
    public static CreateDeliveryCommand ToCommandFromResource(CreateDeliveryResource resource) =>
        new(
            resource.OrderId,
            resource.DriverName,
            resource.DriverPhone,
            resource.VehiclePlate,
            resource.VehicleType,
            resource.RouteOrigin,
            resource.RouteDestination,
            resource.RouteDistanceKm,
            resource.EstimatedTimeOfArrival
        );
}