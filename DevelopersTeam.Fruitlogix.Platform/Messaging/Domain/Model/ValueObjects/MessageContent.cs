namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.ValueObjects;

public record MessageContent
{
    public string Value { get; }

    public MessageContent(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Message content cannot be empty.");
        if (value.Length > 1000)
            throw new ArgumentException("Message content cannot exceed 1000 characters.");
        Value = value.Trim();
    }
}