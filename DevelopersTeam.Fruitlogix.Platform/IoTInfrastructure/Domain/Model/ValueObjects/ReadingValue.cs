namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;

public record ReadingValue
{
    public double Value { get; }
    public string Unit { get; }

    private static readonly HashSet<string> AllowedUnits = ["°C", "%", "km/h", "kg"];

    public ReadingValue(double value, string unit)
    {
        if (!AllowedUnits.Contains(unit))
            throw new ArgumentException($"Unit '{unit}' is not supported.");
        Value = value;
        Unit = unit;
    }

    protected ReadingValue() { } // EF Core
}