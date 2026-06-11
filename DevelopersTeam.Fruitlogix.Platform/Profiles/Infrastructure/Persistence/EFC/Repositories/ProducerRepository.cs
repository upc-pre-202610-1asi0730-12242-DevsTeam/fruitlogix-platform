using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProducerRepository(AppDbContext context)
    : BaseRepository<Producer>(context), IProducerRepository
{
    public async Task<bool> ExistsByTaxIdAsync(string taxId) =>
        await Context.Set<Producer>()
            .AnyAsync(p => p.TaxId.Value == taxId);
}