using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.CommandServices;

public class ConversationCommandService(
    IConversationRepository conversationRepository,
    IUnitOfWork unitOfWork
) : IConversationCommandService
{
    public async Task<Conversation> Handle(CreateConversationCommand command)
    {
        if (await conversationRepository.ExistsByOrderIdAsync(command.OrderId))
            throw new InvalidOperationException(
                $"A conversation for order {command.OrderId} already exists.");

        var conversation = new Conversation(command);
        await conversationRepository.AddAsync(conversation);
        await unitOfWork.CompleteAsync();
        return conversation;
    }
}