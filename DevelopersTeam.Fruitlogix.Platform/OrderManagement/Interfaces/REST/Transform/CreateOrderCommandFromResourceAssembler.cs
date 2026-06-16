using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        var items = resource.Items.Select(i => new CreateOrderItemCommand(
            i.ProductId,
            i.ProductName,
            i.QuantityKg,
            i.UnitPrice,
            i.Subtotal)).ToList();

        return new CreateOrderCommand(
            resource.CommercialClientId,
            resource.DeliveryDueDate,
            resource.DeliveryAddress,
            resource.TotalAmount,
            resource.Notes,
            items
        );
    }
}