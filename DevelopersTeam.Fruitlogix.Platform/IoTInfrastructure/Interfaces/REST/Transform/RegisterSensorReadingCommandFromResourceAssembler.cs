using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class RegisterSensorReadingCommandFromResourceAssembler
{
    public static RegisterSensorReadingCommand ToCommandFromResource(RegisterSensorReadingResource resource) =>
        new(resource.DeviceId, resource.Value, resource.Unit, resource.Timestamp);
}