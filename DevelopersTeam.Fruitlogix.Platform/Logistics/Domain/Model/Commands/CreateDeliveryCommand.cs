namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;

public record CreateDeliveryCommand(
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