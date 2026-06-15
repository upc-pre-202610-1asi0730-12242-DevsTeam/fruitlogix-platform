using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class AlertRuleResourceFromEntityAssembler
{
    public static AlertRuleResource ToResourceFromEntity(AlertRule entity) =>
        new(
            entity.Id,
            entity.DeviceType.ToString(),
            entity.Threshold.Min,
            entity.Threshold.Max,
            entity.AlertMessage,
            entity.Severity.ToString(),
            entity.IsActive
        );
}