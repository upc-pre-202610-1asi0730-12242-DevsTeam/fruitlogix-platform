using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;

public class QualityInspection : IAuditableEntity
{
    public int Id { get; private set; }
    public int BatchId { get; private set; }
    public string? Notes { get; private set; }

    // Navegación EF Core — owned entities
    public VisualInspection VisualInspection { get; private set; } = null!;
    public TechnicalParameters TechnicalParameters { get; private set; } = null!;
    public PreparationChecklist PreparationChecklist { get; private set; } = null!;

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public QualityInspection() { }

    public QualityInspection(
        int batchId,
        string? notes,
        AppearanceRating appearanceRating,
        VisualDefects visualDefects,
        WastePercentage wastePercentage,
        double temperatureCelsius,
        double humidityPercent,
        double ph,
        BrixDegrees brixDegrees,
        bool dryCleaningDone,
        bool caliberSortingConfirmed,
        bool packagingMaterialInspected,
        bool finalBoxSealing)
    {
        BatchId = batchId;
        Notes   = notes;

        // Las entities se crean con Id=0; EF Core les asignará el Id
        // una vez que QualityInspection sea persistida y obtenga su propio Id.
        // Por eso usamos el método interno SetSubEntities() llamado desde el Service
        // DESPUÉS del primer SaveChanges, cuando ya tenemos this.Id disponible.
        VisualInspection = new VisualInspection(
            0, appearanceRating, visualDefects, wastePercentage);

        TechnicalParameters = new TechnicalParameters(
            0, temperatureCelsius, humidityPercent, ph, brixDegrees);

        PreparationChecklist = new PreparationChecklist(
            0, dryCleaningDone, caliberSortingConfirmed,
            packagingMaterialInspected, finalBoxSealing);
    }

    // Llamado desde el CommandService tras el primer SaveChanges
    // para fijar el FK correcto en las sub-entities.
    public void BindSubEntities()
    {
        VisualInspection     = new VisualInspection(
            Id,
            new AppearanceRating(VisualInspection.AppearanceRating),
            new VisualDefects(
                VisualInspection.HasStains,
                VisualInspection.HasBruises,
                VisualInspection.HasDeformations,
                VisualInspection.HasRot),
            new WastePercentage(VisualInspection.WastePercentage));

        TechnicalParameters  = new TechnicalParameters(
            Id,
            TechnicalParameters.TemperatureCelsius,
            TechnicalParameters.HumidityPercent,
            TechnicalParameters.Ph,
            new BrixDegrees(TechnicalParameters.BrixDegrees));

        PreparationChecklist = new PreparationChecklist(
            Id,
            PreparationChecklist.DryCleaningDone,
            PreparationChecklist.CaliberSortingConfirmed,
            PreparationChecklist.PackagingMaterialInspected,
            PreparationChecklist.FinalBoxSealing);
    }
}