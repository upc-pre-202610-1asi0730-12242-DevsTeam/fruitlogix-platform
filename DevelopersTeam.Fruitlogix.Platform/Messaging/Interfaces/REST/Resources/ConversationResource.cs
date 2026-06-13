namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;

public record ConversationResource(
    int Id,
    int OrderId,
    int ParticipantAId,
    int ParticipantBId,
    DateTimeOffset? CreatedAt
);