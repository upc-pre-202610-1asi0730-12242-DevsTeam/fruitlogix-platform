using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Application.QueryServices;

public interface IProducerQueryService
{
    Task<IEnumerable<Producer>> Handle(GetAllProducersQuery query);
}