using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;

public interface IMessageQueryService
{
    Task<IEnumerable<Message>> Handle(GetMessagesByConversationIdQuery query);
}