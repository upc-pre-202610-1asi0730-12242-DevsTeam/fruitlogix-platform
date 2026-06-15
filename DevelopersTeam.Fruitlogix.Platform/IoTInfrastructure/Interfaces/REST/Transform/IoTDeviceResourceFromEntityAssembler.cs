using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class IoTDeviceResourceFromEntityAssembler
{
    public static IoTDeviceResource ToResourceFromEntity(IoTDevice entity) =>
        new(
            entity.Id,
            entity.DeviceCode.Value,
            entity.DeviceType.ToString(),
            entity.Location,
            entity.Status.ToString(),
            entity.LastReadingAt
        );
}