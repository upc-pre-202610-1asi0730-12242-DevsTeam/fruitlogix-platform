using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.ValueObjects;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Commands;

public record UpdateIncidentStatusCommand(int IncidentId, IncidentStatus NewStatus);