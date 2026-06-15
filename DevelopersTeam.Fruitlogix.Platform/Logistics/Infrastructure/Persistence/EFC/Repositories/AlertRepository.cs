using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class AlertRepository : BaseRepository<Alert>, IAlertRepository
{
    public AlertRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Alert>> FindActiveAlertsAsync()
    {
        return await Context.Set<Alert>()
            .Where(a => !a.IsResolved)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }
}