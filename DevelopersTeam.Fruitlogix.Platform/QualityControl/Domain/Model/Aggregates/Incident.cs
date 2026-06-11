using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;

public class Incident : IAuditableEntity
{
    public int Id { get; private set; }
    public int BatchId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string EvidenceUrls { get; private set; } = string.Empty; // JSON serializado
    public IncidentStatus Status { get; private set; }
    public DateTimeOffset? ResolvedAt { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public Incident() { }

    public Incident(int batchId, string description, List<string> evidenceUrls)
    {
        BatchId      = batchId;
        Description  = description;
        EvidenceUrls = System.Text.Json.JsonSerializer.Serialize(evidenceUrls);
        Status       = IncidentStatus.Open;
        ResolvedAt   = null;
    }

    // Helpers para que el Controller/Service no trabajen con JSON crudo
    public List<string> GetEvidenceUrls() =>
        System.Text.Json.JsonSerializer.Deserialize<List<string>>(EvidenceUrls) ?? [];

    public void UpdateStatus(IncidentStatus newStatus)
    {
        Status     = newStatus;
        ResolvedAt = newStatus == IncidentStatus.Resolved
            ? DateTimeOffset.UtcNow
            : ResolvedAt;
    }
}