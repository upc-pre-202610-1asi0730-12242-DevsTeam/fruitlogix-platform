using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;

public interface IAlertRuleCommandService
{
    Task<AlertRule> Handle(CreateAlertRuleCommand command);
}