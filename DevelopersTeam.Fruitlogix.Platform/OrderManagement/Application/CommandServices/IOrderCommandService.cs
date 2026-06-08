using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
    Task<Order?> Handle(UpdateOrderCommand command);
    Task<Order?> Handle(AssignProducerCommand command);
    Task<Order?> Handle(CancelOrderCommand command);
}