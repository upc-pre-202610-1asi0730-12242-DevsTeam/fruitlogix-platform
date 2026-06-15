namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

public record CreateDeliveryResource(
    int      OrderId,
    string   DriverName,
    string   DriverPhone,
    string   VehiclePlate,
    string   VehicleType,
    string   RouteOrigin,
    string   RouteDestination,
    double   RouteDistanceKm,
    DateTime EstimatedTimeOfArrival
);