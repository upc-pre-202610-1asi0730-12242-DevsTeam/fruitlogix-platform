namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;

public record CreateConversationResource(
    int OrderId,
    int ParticipantAId,
    int ParticipantBId
);