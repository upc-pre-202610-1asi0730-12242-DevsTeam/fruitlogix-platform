namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

public record TrackingLogResource(
    int      Id,
    int      DeliveryId,
    DateTime Timestamp,
    double   Latitude,
    double   Longitude,
    double   Temperature,
    double   Humidity
);