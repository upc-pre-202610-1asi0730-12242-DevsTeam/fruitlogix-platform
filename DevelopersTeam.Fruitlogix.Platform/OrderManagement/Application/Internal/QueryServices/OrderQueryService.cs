using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query) =>
        await orderRepository.ListAsync();

    public async Task<Order?> Handle(GetOrderByIdQuery query) =>
        await orderRepository.FindByIdAsync(query.OrderId);

    public async Task<IEnumerable<Order>> Handle(GetOrdersByClientIdQuery query) =>
        await orderRepository.FindByClientIdAsync(query.CommercialClientId);
}