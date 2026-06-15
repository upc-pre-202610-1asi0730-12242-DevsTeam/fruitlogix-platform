namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

public record IncidentResource(
    int Id,
    int BatchId,
    string Description,
    List<string> EvidenceUrls,
    string Status,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? ResolvedAt
);