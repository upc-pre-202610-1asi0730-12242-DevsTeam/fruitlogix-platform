using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.CommandServices;

public class IoTDeviceCommandService(
    IIoTDeviceRepository repository,
    IUnitOfWork unitOfWork) : IIoTDeviceCommandService
{
    public async Task<IoTDevice?> Handle(UpdateIoTDeviceCommand command)
    {
        var device = await repository.FindByIdAsync(command.Id);
        if (device is null) return null;

        switch (command.TargetStatus.ToUpperInvariant())
        {
            case "MAINTENANCE":
                device.Calibrate();
                break;
            case "ACTIVE":
                device.Activate();
                break;
            default:
                throw new ArgumentException($"Status '{command.TargetStatus}' is not a valid target status.");
        }

        repository.Update(device);
        await unitOfWork.CompleteAsync();
        return device;
    }
}