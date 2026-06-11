namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.ValueObjects;

public record ProductionInfo
{
    public string Crop                { get; }
    public double CultivatedHectares  { get; }
    public string MonthlyProduction   { get; }

    public ProductionInfo(string crop, double cultivatedHectares, string monthlyProduction)
    {
        if (string.IsNullOrWhiteSpace(crop))
            throw new ArgumentException("Crop is required.");
        if (cultivatedHectares < 0)
            throw new ArgumentException("CultivatedHectares cannot be negative.");
        Crop               = crop;
        CultivatedHectares = cultivatedHectares;
        MonthlyProduction  = monthlyProduction ?? string.Empty;
    }
}