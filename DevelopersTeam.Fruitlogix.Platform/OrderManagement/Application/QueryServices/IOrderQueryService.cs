using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
    Task<IEnumerable<Order>> Handle(GetOrdersByClientIdQuery query);
    Task<IEnumerable<Order>> Handle(GetOrdersByProducerIdQuery query);

}