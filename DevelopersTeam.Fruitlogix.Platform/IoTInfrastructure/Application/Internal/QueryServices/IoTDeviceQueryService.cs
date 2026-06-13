using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.QueryServices;

public class IoTDeviceQueryService(IIoTDeviceRepository repository)
    : IIoTDeviceQueryService
{
    public async Task<IEnumerable<IoTDevice>> Handle(GetAllDevicesQuery query)
        => await repository.ListAsync();
}