using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;

public class HarvestBatch : IAuditableEntity
{
    public int Id { get; private set; }
    public int ProducerId { get; private set; }
    public string FruitType { get; private set; } = string.Empty;
    public double QuantityKg { get; private set; }
    public DateOnly HarvestDate { get; private set; }
    public BatchStatus Status { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    // Constructor vacío requerido por EF Core
    public HarvestBatch() { }

    public HarvestBatch(int producerId, string fruitType, double quantityKg, DateOnly harvestDate)
    {
        ProducerId   = producerId;
        FruitType    = fruitType;
        QuantityKg   = quantityKg;
        HarvestDate  = harvestDate;
        Status       = BatchStatus.Pending;
    }
}