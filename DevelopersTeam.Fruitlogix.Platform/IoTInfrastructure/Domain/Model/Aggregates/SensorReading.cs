using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;

public class SensorReading : IAuditableEntity
{
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public ReadingValue Reading { get; private set; } = null!;
    public DateTimeOffset Timestamp { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected SensorReading() { }

    public SensorReading(RegisterSensorReadingCommand command)
    {
        DeviceId = command.DeviceId;
        Reading = new ReadingValue(command.Value, command.Unit);
        Timestamp = command.Timestamp ?? DateTimeOffset.UtcNow;
    }
}