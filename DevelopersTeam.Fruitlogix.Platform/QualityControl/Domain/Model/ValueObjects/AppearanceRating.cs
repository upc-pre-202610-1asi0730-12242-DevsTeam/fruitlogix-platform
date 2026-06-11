namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;

public record AppearanceRating
{
    public int Value { get; }

    public AppearanceRating(int value)
    {
        if (value < 1 || value > 5)
            throw new ArgumentException("Appearance rating must be between 1 and 5.");
        Value = value;
    }
}