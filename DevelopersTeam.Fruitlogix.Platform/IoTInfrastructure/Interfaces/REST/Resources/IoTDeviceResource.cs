namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

public record IoTDeviceResource(
    int Id,
    string DeviceCode,
    string DeviceType,
    string Location,
    string Status,
    DateTimeOffset? LastReadingAt
);