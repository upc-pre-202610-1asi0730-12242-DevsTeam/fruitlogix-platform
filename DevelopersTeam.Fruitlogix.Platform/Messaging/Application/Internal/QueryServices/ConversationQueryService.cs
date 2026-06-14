using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.QueryServices;

public class ConversationQueryService(
    IConversationRepository conversationRepository
) : IConversationQueryService
{
    public async Task<IEnumerable<Conversation>> Handle(GetAllConversationsQuery query) =>
        await conversationRepository.ListAsync();

    public async Task<IEnumerable<Conversation>> Handle(GetConversationsByUserIdQuery query) =>
        await conversationRepository.FindByUserIdAsync(query.UserId);
}