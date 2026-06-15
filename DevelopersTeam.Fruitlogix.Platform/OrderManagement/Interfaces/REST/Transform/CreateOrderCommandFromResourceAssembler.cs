using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource) =>
        new(
            resource.CommercialClientId,
            resource.ProducerId,
            resource.DeliveryDueDate,
            resource.FruitType,
            resource.TotalVolume,
            resource.TotalAmount,
            resource.Notes,
            resource.Items.Select(i =>
                new CreateOrderItemCommand(i.FruitName, i.QuantityKg, i.UnitPrice)).ToList()
        );
}