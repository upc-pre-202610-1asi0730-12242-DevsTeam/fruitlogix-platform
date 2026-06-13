using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Infrastructure.Persistence.EFC.Repositories;

public class IoTDeviceRepository(AppDbContext context)
    : BaseRepository<IoTDevice>(context), IIoTDeviceRepository
{
}