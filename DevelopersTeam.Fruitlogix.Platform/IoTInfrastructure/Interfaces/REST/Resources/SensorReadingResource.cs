namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

public record SensorReadingResource(
    int Id,
    int DeviceId,
    double Value,
    string Unit,
    DateTimeOffset Timestamp
);