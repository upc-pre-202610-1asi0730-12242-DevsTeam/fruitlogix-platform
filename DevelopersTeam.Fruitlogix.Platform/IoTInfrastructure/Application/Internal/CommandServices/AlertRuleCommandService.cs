using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.CommandServices;

public class AlertRuleCommandService(
    IAlertRuleRepository repository,
    IUnitOfWork unitOfWork) : IAlertRuleCommandService
{
    public async Task<AlertRule> Handle(CreateAlertRuleCommand command)
    {
        var rule = new AlertRule(command);
        await repository.AddAsync(rule);
        await unitOfWork.CompleteAsync();
        return rule;
    }
}