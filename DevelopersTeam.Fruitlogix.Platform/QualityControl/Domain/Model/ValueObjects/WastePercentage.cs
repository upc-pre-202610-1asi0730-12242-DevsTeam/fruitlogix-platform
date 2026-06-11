namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;

public record WastePercentage
{
    public double Value { get; }

    public WastePercentage(double value)
    {
        if (value < 0 || value > 100)
            throw new ArgumentException("Waste percentage must be between 0 and 100.");
        Value = value;
    }
}