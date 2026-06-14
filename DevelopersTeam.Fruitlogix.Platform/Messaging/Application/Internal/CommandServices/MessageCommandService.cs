using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.CommandServices;

public class MessageCommandService(
    IConversationRepository conversationRepository,
    IUnitOfWork unitOfWork
) : IMessageCommandService
{
    public async Task<Message> Handle(AddMessageToConversationCommand command)
    {
        var conversation = await conversationRepository.FindByIdAsync(command.ConversationId)
                           ?? throw new KeyNotFoundException(
                               $"Conversation {command.ConversationId} not found.");

        conversation.AddMessage(command.SenderId, command.Content);

        await unitOfWork.CompleteAsync();

        return conversation.Messages.Last();
    }
}