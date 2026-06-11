using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;

public interface IDeliveryQueryService
{
    Task<IEnumerable<Delivery>> Handle(GetAllDeliveriesQuery query);
}