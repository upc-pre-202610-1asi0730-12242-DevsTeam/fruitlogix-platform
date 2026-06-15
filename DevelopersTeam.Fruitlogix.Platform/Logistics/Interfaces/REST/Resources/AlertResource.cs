namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

public record AlertResource(
    int    Id,
    int    DeliveryId,
    string Type,
    string Severity,
    string Message,
    bool   IsResolved,
    DateTimeOffset? CreatedAt
);