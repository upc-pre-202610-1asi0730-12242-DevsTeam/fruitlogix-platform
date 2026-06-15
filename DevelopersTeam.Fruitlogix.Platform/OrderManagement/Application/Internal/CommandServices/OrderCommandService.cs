using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.CommandServices;

public class OrderCommandService(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        var order = new Order(command);
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        return order;
    }

    public async Task<Order?> Handle(UpdateOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order is null) return null;
        order.UpdateDetails(command);
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
        return order;
    }

    public async Task<Order?> Handle(AssignProducerCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order is null) return null;
        order.AssignProducer(command);
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
        return order;
    }

    public async Task<Order?> Handle(CancelOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order is null) return null;
        order.Cancel(command);
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
        return order;
    }
    
    public async Task<Order?> Handle(ConfirmOrderReceptionCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order is null) return null;

        order.ConfirmReception(command.Rating, command.Comment, command.HasIncidence);
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();

        return order;
    }
}