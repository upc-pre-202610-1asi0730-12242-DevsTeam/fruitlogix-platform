using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;

public interface IConversationRepository : IBaseRepository<Conversation>
{
    Task<bool> ExistsByOrderIdAsync(int orderId);
    Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId);

}