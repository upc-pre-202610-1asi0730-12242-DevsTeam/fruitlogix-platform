using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
{
    public DeliveryRepository(AppDbContext context) : base(context) { }
}