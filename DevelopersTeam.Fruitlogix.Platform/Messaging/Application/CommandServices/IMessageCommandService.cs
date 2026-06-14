using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;

public interface IMessageCommandService
{
    Task<Message> Handle(AddMessageToConversationCommand command);
}