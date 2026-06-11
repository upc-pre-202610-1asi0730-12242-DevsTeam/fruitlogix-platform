using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;

public interface IDeliveryCommandService
{
    Task<Delivery> Handle(CreateDeliveryCommand command);
}