namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.ValueObjects;

public record TaxId
{
    public string Value { get; }

    public TaxId(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{11}$"))
            throw new ArgumentException("TaxId must be exactly 11 numeric digits.");
        Value = value;
    }
}