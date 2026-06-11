using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Repositories;

public interface IProducerRepository : IBaseRepository<Producer>
{
    Task<bool> ExistsByTaxIdAsync(string taxId);
    
    Task<Producer?> FindByTaxIdAsync(string taxId);
}