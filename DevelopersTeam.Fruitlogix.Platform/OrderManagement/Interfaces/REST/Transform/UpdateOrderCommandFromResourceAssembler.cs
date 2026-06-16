using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(int orderId, UpdateOrderResource resource) =>
        new(
            orderId,
            resource.DeliveryDueDate,
            resource.DeliveryAddress,
            resource.TotalAmount,
            resource.Notes
        );
}