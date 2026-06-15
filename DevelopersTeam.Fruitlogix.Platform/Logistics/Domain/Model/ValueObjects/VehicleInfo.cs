namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;

public record VehicleInfo
{
    public string Plate { get; }
    public string Type  { get; }

    public VehicleInfo(string plate, string type)
    {
        if (string.IsNullOrWhiteSpace(plate))
            throw new ArgumentException("Vehicle plate is required.");
        Plate = plate.Trim().ToUpperInvariant();
        Type  = type?.Trim() ?? string.Empty;
    }
}