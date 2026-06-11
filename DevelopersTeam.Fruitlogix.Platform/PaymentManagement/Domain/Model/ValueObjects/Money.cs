namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency = "PEN")
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code.");
        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }
}