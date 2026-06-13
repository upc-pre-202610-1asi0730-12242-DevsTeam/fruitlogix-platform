using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.QueryServices;

public class SensorReadingQueryService(ISensorReadingRepository repository)
    : ISensorReadingQueryService
{
    public async Task<IEnumerable<SensorReading>> Handle(GetAllSensorReadingsQuery query)
        => await repository.ListAsync();
}