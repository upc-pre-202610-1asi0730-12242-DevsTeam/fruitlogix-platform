using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Infrastructure.Persistence.EFC.Repositories;

public class QualityInspectionRepository(AppDbContext context)
    : BaseRepository<QualityInspection>(context), IQualityInspectionRepository
{
    public async Task<QualityInspection?> FindByBatchIdAsync(int batchId) =>
        await context.Set<QualityInspection>()
            .Include(q => q.VisualInspection)
            .Include(q => q.TechnicalParameters)
            .Include(q => q.PreparationChecklist)
            .FirstOrDefaultAsync(q => q.BatchId == batchId);
}