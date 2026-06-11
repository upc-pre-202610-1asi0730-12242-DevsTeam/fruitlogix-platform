namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

public record CreateIncidentCommand(
    int BatchId,
    string Description,
    List<string> EvidenceUrls
);