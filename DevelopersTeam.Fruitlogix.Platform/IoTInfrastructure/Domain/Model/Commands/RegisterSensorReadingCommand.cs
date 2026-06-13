namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;

public record RegisterSensorReadingCommand(
    int DeviceId,
    double Value,
    string Unit,
    DateTimeOffset? Timestamp
);