namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;

public record DriverInfo
{
    public string Name  { get; }
    public string Phone { get; }

    public DriverInfo(string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Driver name is required.");
        Name  = name.Trim();
        Phone = phone?.Trim() ?? string.Empty;
    }
}