namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.ValueObjects;

public record Location
{
    public string Country { get; }
    public string Region  { get; }
    public string City    { get; }
    public string Address { get; }

    public Location(string country, string region, string city, string address)
    {
        Country = country ?? string.Empty;
        Region  = region  ?? string.Empty;
        City    = city    ?? string.Empty;
        Address = address ?? string.Empty;
    }
}