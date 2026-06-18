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

    // Para EF Core — sin validación
    private DeliveryDate(DateOnly value, bool skipValidation)
    {
        Value = value;
    }

    public static DeliveryDate FromDatabase(DateOnly value) => new(value, true);
}