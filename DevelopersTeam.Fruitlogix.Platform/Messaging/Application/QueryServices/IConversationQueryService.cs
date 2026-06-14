using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;

public interface IConversationQueryService
{
    Task<IEnumerable<Conversation>> Handle(GetAllConversationsQuery query);
    Task<IEnumerable<Conversation>> Handle(GetConversationsByUserIdQuery query);
}