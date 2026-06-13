using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;

public static class CreateAlertRuleCommandFromResourceAssembler
{
    public static CreateAlertRuleCommand ToCommandFromResource(CreateAlertRuleResource resource) =>
        new(
            resource.DeviceType,
            resource.MinThreshold,
            resource.MaxThreshold,
            resource.AlertMessage,
            resource.Severity,
            resource.IsActive
        );
}