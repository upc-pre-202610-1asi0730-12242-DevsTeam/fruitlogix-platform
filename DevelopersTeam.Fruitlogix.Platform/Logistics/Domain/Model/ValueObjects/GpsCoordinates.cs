namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;

public record GpsCoordinates
{
    public double Latitude  { get; }
    public double Longitude { get; }

    public GpsCoordinates(double latitude, double longitude)
    {
        if (latitude  < -90  || latitude  > 90)
            throw new ArgumentException("Latitude must be between -90 and 90.");
        if (longitude < -180 || longitude > 180)
            throw new ArgumentException("Longitude must be between -180 and 180.");
        Latitude  = latitude;
        Longitude = longitude;
    }

    public override string ToString() => $"{Latitude},{Longitude}";
}