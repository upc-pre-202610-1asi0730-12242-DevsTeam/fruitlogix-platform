using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class UpdateIoTDeviceCommandFromResourceAssembler
{
    public static UpdateIoTDeviceCommand ToCommandFromResource(int id, UpdateIoTDeviceResource resource) =>
        new(id, resource.TargetStatus);
}