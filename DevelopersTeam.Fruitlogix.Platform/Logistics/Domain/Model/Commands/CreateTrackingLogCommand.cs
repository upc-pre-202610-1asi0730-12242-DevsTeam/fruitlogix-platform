namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;

public record CreateTrackingLogCommand(
    int      DeliveryId,
    DateTime Timestamp,
    double   Latitude,
    double   Longitude,
    double   Temperature,
    double   Humidity
);