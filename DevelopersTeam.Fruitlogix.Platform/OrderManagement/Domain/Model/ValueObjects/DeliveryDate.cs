namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;

public record DeliveryDate
{
    public DateOnly Value { get; }

    public DeliveryDate(DateOnly value)
    {
        if (value <= DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Delivery date must be in the future.");
        Value = value;
    }
}