namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;

public record RouteInfo
{
    public string Origin      { get; }
    public string Destination { get; }
    public double DistanceKm  { get; }

    public RouteInfo(string origin, string destination, double distanceKm)
    {
        if (string.IsNullOrWhiteSpace(origin))
            throw new ArgumentException("Origin is required.");
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("Destination is required.");
        if (distanceKm <= 0)
            throw new ArgumentException("Distance must be greater than zero.");
        Origin      = origin.Trim();
        Destination = destination.Trim();
        DistanceKm  = distanceKm;
    }
}