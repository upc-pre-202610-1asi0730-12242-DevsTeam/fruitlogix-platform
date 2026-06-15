namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;

public record AlertRuleResource(
    int Id,
    string DeviceType,
    double MinThreshold,
    double MaxThreshold,
    string AlertMessage,
    string Severity,
    bool IsActive
);