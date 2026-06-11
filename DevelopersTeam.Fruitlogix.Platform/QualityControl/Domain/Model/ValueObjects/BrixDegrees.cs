namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;

public record BrixDegrees
{
    public double Value { get; }

    public BrixDegrees(double value)
    {
        if (value <= 0)
            throw new ArgumentException("Brix degrees must be greater than 0.");
        Value = value;
    }
}