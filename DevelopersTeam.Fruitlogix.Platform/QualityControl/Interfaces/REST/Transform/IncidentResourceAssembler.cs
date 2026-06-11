using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;

public static class IncidentResourceAssembler
{
    public static CreateIncidentCommand ToCommandFromResource(CreateIncidentResource resource) =>
        new(resource.BatchId, resource.Description, resource.EvidenceUrls);

    public static IncidentResource ToResourceFromEntity(Incident entity) =>
        new(
            entity.Id,
            entity.BatchId,
            entity.Description,
            entity.GetEvidenceUrls(),
            entity.Status.ToString(),
            entity.CreatedAt,
            entity.ResolvedAt
        );
    
    public static UpdateIncidentStatusCommand ToCommandFromResource(
        int incidentId, UpdateIncidentStatusResource resource)
    {
        if (!Enum.TryParse<IncidentStatus>(resource.Status, ignoreCase: true, out var status))
            throw new ArgumentException($"Invalid status value: '{resource.Status}'.");

        return new UpdateIncidentStatusCommand(incidentId, status);
    }
    
}