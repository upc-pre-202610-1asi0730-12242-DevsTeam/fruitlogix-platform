using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;

public class AlertRule : IAuditableEntity
{
    public int Id { get; private set; }
    public DeviceType DeviceType { get; private set; }
    public ThresholdRange Threshold { get; private set; } = null!;
    public string AlertMessage { get; private set; } = string.Empty;
    public AlertSeverity Severity { get; private set; }
    public bool IsActive { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected AlertRule() { }

    public AlertRule(CreateAlertRuleCommand command)
    {
        DeviceType = Enum.Parse<DeviceType>(command.DeviceType, ignoreCase: true);
        Threshold = new ThresholdRange(command.MinThreshold, command.MaxThreshold);
        AlertMessage = command.AlertMessage;
        Severity = Enum.Parse<AlertSeverity>(command.Severity, ignoreCase: true);
        IsActive = command.IsActive;
    }
}