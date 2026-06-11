using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Entities;

public class TechnicalParameters : IAuditableEntity
{
    public int Id { get; private set; }
    public int QualityInspectionId { get; private set; }

    public double TemperatureCelsius { get; private set; }
    public double HumidityPercent { get; private set; }
    public double Ph { get; private set; }

    // BrixDegrees almacenado como double en BD
    public double BrixDegrees { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public TechnicalParameters() { }

    public TechnicalParameters(
        int qualityInspectionId,
        double temperatureCelsius,
        double humidityPercent,
        double ph,
        BrixDegrees brixDegrees)
    {
        QualityInspectionId = qualityInspectionId;
        TemperatureCelsius  = temperatureCelsius;
        HumidityPercent     = humidityPercent;
        Ph                  = ph;
        BrixDegrees         = brixDegrees.Value;
    }
}