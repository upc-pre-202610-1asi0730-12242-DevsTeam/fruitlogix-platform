namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

public record DeliveryResource(
    int      Id,
    int      OrderId,
    string   DriverName,
    string   DriverPhone,
    string   VehiclePlate,
    string   VehicleType,
    string   RouteOrigin,
    string   RouteDestination,
    double   RouteDistanceKm,
    DateTime EstimatedTimeOfArrival,
    string   CurrentStatus
);