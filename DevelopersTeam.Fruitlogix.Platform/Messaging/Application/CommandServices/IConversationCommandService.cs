using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;

public interface IConversationCommandService
{
    Task<Conversation> Handle(CreateConversationCommand command);
}