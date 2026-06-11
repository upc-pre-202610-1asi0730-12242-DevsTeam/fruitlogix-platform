namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;

public record DueDate
{
    public DateOnly Value { get; }

    public DueDate(DateOnly value)
    {
        if (value <= DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Due date must be in the future.");
        Value = value;
    }
}