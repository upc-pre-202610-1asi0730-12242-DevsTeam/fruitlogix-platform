using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.QueryServices;

public class IncidentQueryService(
    IIncidentRepository incidentRepository
) : IIncidentQueryService
{
    public async Task<IEnumerable<Incident>> Handle(GetAllIncidentsQuery query) =>
        await incidentRepository.ListAsync();
}