namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

public record CreateTrackingLogResource(
    int      DeliveryId,
    DateTime Timestamp,
    double   Latitude,
    double   Longitude,
    double   Temperature,
    double   Humidity
);