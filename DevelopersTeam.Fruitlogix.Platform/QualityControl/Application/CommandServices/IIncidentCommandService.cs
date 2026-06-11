using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;

public interface IIncidentCommandService
{
    Task<Incident> Handle(CreateIncidentCommand command);
    Task<Incident?> Handle(UpdateIncidentStatusCommand command);  // ← nuevo
}