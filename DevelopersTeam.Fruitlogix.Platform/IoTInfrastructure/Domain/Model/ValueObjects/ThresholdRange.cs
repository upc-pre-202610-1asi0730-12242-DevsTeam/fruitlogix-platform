namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;

public record ThresholdRange
{
    public double Min { get; }
    public double Max { get; }

    public ThresholdRange(double min, double max)
    {
        if (min >= max)
            throw new ArgumentException("Min threshold must be less than Max threshold.");
        Min = min;
        Max = max;
    }

    protected ThresholdRange() { } // EF Core
}