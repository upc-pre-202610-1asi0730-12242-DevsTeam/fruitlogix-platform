using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;

public static class AlertResourceFromEntityAssembler
{
    public static AlertResource ToResourceFromEntity(Alert entity) =>
        new(
            entity.Id,
            entity.DeliveryId,
            entity.Type.ToString(),
            entity.Severity.ToString(),
            entity.Message,
            entity.IsResolved,
            entity.CreatedAt
        );
}