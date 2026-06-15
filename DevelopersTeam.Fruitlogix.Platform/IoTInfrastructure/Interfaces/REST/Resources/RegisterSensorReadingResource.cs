namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

public record RegisterSensorReadingResource(
    int DeviceId,
    double Value,
    string Unit,
    DateTimeOffset? Timestamp
);