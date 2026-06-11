using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;

public static class QualityInspectionResourceAssembler
{
    public static CreateQualityInspectionCommand ToCommandFromResource(
        CreateQualityInspectionResource resource) =>
        new(
            resource.BatchId,
            resource.Notes,
            resource.AppearanceRating,
            resource.HasStains,
            resource.HasBruises,
            resource.HasDeformations,
            resource.HasRot,
            resource.WastePercentage,
            resource.TemperatureCelsius,
            resource.HumidityPercent,
            resource.Ph,
            resource.BrixDegrees,
            resource.DryCleaningDone,
            resource.CaliberSortingConfirmed,
            resource.PackagingMaterialInspected,
            resource.FinalBoxSealing
        );

    public static QualityInspectionResource ToResourceFromEntity(QualityInspection entity) =>
        new(
            entity.Id,
            entity.BatchId,
            entity.Notes,
            new VisualInspectionResource(
                entity.VisualInspection.AppearanceRating,
                entity.VisualInspection.HasStains,
                entity.VisualInspection.HasBruises,
                entity.VisualInspection.HasDeformations,
                entity.VisualInspection.HasRot,
                entity.VisualInspection.WastePercentage),
            new TechnicalParametersResource(
                entity.TechnicalParameters.TemperatureCelsius,
                entity.TechnicalParameters.HumidityPercent,
                entity.TechnicalParameters.Ph,
                entity.TechnicalParameters.BrixDegrees),
            new PreparationChecklistResource(
                entity.PreparationChecklist.DryCleaningDone,
                entity.PreparationChecklist.CaliberSortingConfirmed,
                entity.PreparationChecklist.PackagingMaterialInspected,
                entity.PreparationChecklist.FinalBoxSealing)
        );
}