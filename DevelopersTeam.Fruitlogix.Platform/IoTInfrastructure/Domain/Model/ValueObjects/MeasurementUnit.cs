namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;

public record MeasurementUnit
{
    public string Value { get; }

    private static readonly HashSet<string> Allowed = ["°C", "%", "km/h", "kg"];

    public MeasurementUnit(string value)
    {
        if (!Allowed.Contains(value))
            throw new ArgumentException($"MeasurementUnit '{value}' is not supported.");
        Value = value;
    }

    protected MeasurementUnit() { }
}