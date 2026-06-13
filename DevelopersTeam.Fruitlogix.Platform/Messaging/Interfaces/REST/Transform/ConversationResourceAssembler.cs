using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Transform;

public static class ConversationResourceAssembler
{
    public static CreateConversationCommand ToCommandFromResource(
        CreateConversationResource resource) =>
        new(resource.OrderId, resource.ParticipantAId, resource.ParticipantBId);

    public static ConversationResource ToResourceFromEntity(Conversation conversation) =>
        new(
            conversation.Id,
            conversation.OrderId,
            conversation.ParticipantAId,
            conversation.ParticipantBId,
            conversation.CreatedAt
        );
}