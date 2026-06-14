using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.QueryServices;

public class MessageQueryService(
    IConversationRepository conversationRepository
) : IMessageQueryService
{
    public async Task<IEnumerable<Message>> Handle(GetMessagesByConversationIdQuery query)
    {
        var conversationExists = await conversationRepository
            .FindByIdAsync(query.ConversationId);

        if (conversationExists is null)
            throw new KeyNotFoundException(
                $"Conversation {query.ConversationId} not found.");

        return await conversationRepository
            .GetMessagesByConversationIdAsync(query.ConversationId);
    }
}