namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;

public record CardDetails
{
    public string CardEnding { get; }
    public string CardBrand { get; }

    public CardDetails(string cardEnding, string cardBrand)
    {
        if (string.IsNullOrWhiteSpace(cardEnding) || cardEnding.Length != 4)
            throw new ArgumentException("CardEnding must be exactly 4 digits.");
        if (string.IsNullOrWhiteSpace(cardBrand))
            throw new ArgumentException("CardBrand cannot be empty.");
        CardEnding = cardEnding;
        CardBrand = cardBrand.ToUpperInvariant();
    }
}