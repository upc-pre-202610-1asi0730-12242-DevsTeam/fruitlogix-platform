using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Infrastructure.Persistence.EFC.Repositories;

public class ConversationRepository(AppDbContext context)
    : BaseRepository<Conversation>(context), IConversationRepository
{
    public async Task<bool> ExistsByOrderIdAsync(int orderId) =>
        await Context.Set<Conversation>().AnyAsync(c => c.OrderId == orderId);
}