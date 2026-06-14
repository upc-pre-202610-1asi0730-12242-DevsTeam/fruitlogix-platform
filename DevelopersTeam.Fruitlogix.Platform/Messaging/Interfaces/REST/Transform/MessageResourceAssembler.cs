// Messaging/Interfaces/REST/Transform/MessageResourceAssembler.cs
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Transform;

public static class MessageResourceAssembler
{
    public static AddMessageToConversationCommand ToCommandFromResource(
        int conversationId, SendMessageResource resource) =>
        new(conversationId, resource.SenderId, resource.Content);

    public static MessageResource ToResourceFromEntity(Message message) =>
        new(
            message.Id,
            message.SenderId,
            message.Content.Value,
            message.SentAt
        );
}