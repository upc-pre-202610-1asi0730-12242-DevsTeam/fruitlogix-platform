using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;

public interface IIoTDeviceQueryService
{
    Task<IEnumerable<IoTDevice>> Handle(GetAllDevicesQuery query);
    Task<IoTDevice?> Handle(GetIoTDeviceByIdQuery query);  // ← nueva firma
}