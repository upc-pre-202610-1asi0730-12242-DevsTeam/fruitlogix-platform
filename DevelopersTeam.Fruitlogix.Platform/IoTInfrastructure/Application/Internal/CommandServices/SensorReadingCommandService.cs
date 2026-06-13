using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.CommandServices;

public class SensorReadingCommandService(
    ISensorReadingRepository readingRepository,
    IIoTDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork) : ISensorReadingCommandService
{
    public async Task<SensorReading?> Handle(RegisterSensorReadingCommand command)
    {
        var device = await deviceRepository.FindByIdAsync(command.DeviceId);
        if (device is null) return null;

        var reading = new SensorReading(command);
        await readingRepository.AddAsync(reading);

        device.RegisterLastReading();
        deviceRepository.Update(device);

        await unitOfWork.CompleteAsync();
        return reading;
    }
}