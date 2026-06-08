using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context)
    : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>> FindByClientIdAsync(int clientId) =>
        await Context.Set<Order>()
            .Where(o => o.CommercialClientId == clientId)
            .Include(o => o.Items)
            .ToListAsync();

    public async Task<IEnumerable<Order>> FindByProducerIdAsync(int producerId) =>
        await Context.Set<Order>()
            .Where(o => o.ProducerId != null && o.ProducerId.Value == producerId)
            .Include(o => o.Items)
            .ToListAsync();
}