namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;

public record DeviceCode
{
    public string Value { get; }

    public DeviceCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("DeviceCode cannot be empty.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^DEV-\d{3,}$"))
            throw new ArgumentException("DeviceCode must follow the format DEV-XXX.");
        Value = value;
    }

    protected DeviceCode() { } // EF Core
}