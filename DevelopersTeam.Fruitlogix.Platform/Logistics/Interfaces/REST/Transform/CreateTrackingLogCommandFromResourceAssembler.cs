using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;

public static class CreateTrackingLogCommandFromResourceAssembler
{
    public static CreateTrackingLogCommand ToCommandFromResource(CreateTrackingLogResource resource) =>
        new(
            resource.DeliveryId,
            resource.Timestamp,
            resource.Latitude,
            resource.Longitude,
            resource.Temperature,
            resource.Humidity
        );
}