using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;

public interface ISensorReadingQueryService
{
    Task<IEnumerable<SensorReading>> Handle(GetAllSensorReadingsQuery query);
    Task<IEnumerable<SensorReading>> Handle(GetSensorReadingsByDeviceIdQuery query); // ← nueva firma
}