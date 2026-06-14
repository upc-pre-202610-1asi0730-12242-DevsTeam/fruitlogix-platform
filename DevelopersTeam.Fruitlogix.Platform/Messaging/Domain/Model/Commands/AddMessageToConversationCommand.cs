namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;

public record AddMessageToConversationCommand(
    int ConversationId,
    int SenderId,
    string Content
);