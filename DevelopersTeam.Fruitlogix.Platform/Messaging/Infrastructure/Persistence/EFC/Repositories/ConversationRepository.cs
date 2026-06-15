using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
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
    public async Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId)
    {
        var conversation = await Context.Set<Conversation>()
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.Id == conversationId);

        return conversation?.Messages ?? Enumerable.Empty<Message>();
    }
    public async Task<IEnumerable<Conversation>> FindByUserIdAsync(int userId) =>
        await Context.Set<Conversation>()
            .Where(c => c.ParticipantAId == userId || c.ParticipantBId == userId)
            .ToListAsync();
}