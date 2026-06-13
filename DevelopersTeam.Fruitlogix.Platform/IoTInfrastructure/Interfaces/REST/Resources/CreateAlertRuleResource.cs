namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

public record CreateAlertRuleResource(
    string DeviceType,
    double MinThreshold,
    double MaxThreshold,
    string AlertMessage,
    string Severity,
    bool IsActive
);