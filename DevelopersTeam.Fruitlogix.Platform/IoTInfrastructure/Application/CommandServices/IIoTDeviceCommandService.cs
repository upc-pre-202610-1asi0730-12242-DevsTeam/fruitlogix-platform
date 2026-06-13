using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;

public interface IIoTDeviceCommandService
{
    Task<IoTDevice?> Handle(UpdateIoTDeviceCommand command);
}