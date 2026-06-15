using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Application.Internal.QueryServices;

public class ProducerQueryService(IProducerRepository producerRepository) : IProducerQueryService
{
    public async Task<IEnumerable<Producer>> Handle(GetAllProducersQuery query) =>
        await producerRepository.ListAsync();
    
    public async Task<Producer?> Handle(GetProducerByIdQuery query) =>
        await producerRepository.FindByIdAsync(query.Id);
}