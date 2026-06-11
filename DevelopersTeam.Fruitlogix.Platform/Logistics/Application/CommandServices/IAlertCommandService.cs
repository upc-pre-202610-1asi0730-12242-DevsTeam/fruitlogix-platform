using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;

public interface IAlertCommandService
{
    Task<Alert> Handle(CreateAlertCommand command);
    Task<Alert> Handle(ResolveAlertCommand command);
}