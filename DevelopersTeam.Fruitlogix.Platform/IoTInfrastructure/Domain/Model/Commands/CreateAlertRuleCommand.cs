namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;

public record CreateAlertRuleCommand(
    string DeviceType,
    double MinThreshold,
    double MaxThreshold,
    string AlertMessage,
    string Severity,
    bool IsActive
);