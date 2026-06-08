namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;

public record ProducerId
{
    public int Value { get; }

    public ProducerId(int value)
    {
        if (value <= 0)
            throw new ArgumentException("ProducerId must be a positive integer.");
        Value = value;
    }
}