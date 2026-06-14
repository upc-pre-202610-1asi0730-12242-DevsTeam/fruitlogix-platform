using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Entities;

public class Message : IAuditableEntity
{
    public int Id { get; private set; }
    public int SenderId { get; private set; }
    public MessageContent Content { get; private set; } = null!;
    public DateTimeOffset SentAt { get; private set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Message() { }

    internal Message(int senderId, MessageContent content)
    {
        SenderId = senderId;
        Content = content;
        SentAt = DateTimeOffset.UtcNow;
    }
}