using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.CommandServices;

public class IncidentCommandService(
    IIncidentRepository incidentRepository,
    IUnitOfWork unitOfWork
) : IIncidentCommandService
{
    public async Task<Incident> Handle(CreateIncidentCommand command)
    {
        var incident = new Incident(
            command.BatchId,
            command.Description,
            command.EvidenceUrls
        );

        await incidentRepository.AddAsync(incident);
        await unitOfWork.CompleteAsync();

        return incident;
    }
}