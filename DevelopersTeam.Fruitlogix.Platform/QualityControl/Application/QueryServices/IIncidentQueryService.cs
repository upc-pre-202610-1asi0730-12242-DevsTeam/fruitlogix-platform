using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;

public interface IIncidentQueryService
{
    Task<IEnumerable<Incident>> Handle(GetAllIncidentsQuery query);
}