namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;

public record MessageResource(
    int Id,
    int SenderId,
    string Content,
    DateTimeOffset SentAt
);