using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class SensorReadingResourceFromEntityAssembler
{
    public static SensorReadingResource ToResourceFromEntity(SensorReading entity) =>
        new(
            entity.Id,
            entity.DeviceId,
            entity.Reading.Value,
            entity.Reading.Unit,
            entity.Timestamp
        );
}