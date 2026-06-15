using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;

public interface ITrackingLogCommandService
{
    Task<TrackingLog> Handle(CreateTrackingLogCommand command);
}