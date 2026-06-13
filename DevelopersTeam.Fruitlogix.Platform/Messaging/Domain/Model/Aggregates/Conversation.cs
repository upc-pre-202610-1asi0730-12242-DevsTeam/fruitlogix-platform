using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;

public class Conversation : IAuditableEntity
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ParticipantAId { get; private set; }
    public int ParticipantBId { get; private set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Conversation() { }

    public Conversation(CreateConversationCommand command)
    {
        if (command.ParticipantAId == command.ParticipantBId)
            throw new ArgumentException("Participants must be different users.");
        if (command.OrderId <= 0)
            throw new ArgumentException("OrderId must be a valid reference.");

        OrderId = command.OrderId;
        ParticipantAId = command.ParticipantAId;
        ParticipantBId = command.ParticipantBId;
    }
}