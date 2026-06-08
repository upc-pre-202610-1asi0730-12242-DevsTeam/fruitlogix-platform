using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order order) =>
        new(
            order.Id,
            order.CommercialClientId,
            order.ProducerId?.Value,
            order.Status.ToString(),
            order.DeliveryDueDate.Value,
            order.FruitType,
            order.TotalVolume,
            order.TotalAmount,
            order.Notes,
            order.CancellationReason,
            order.Items.Select(i => new OrderItemResource(
                i.Id,
                i.FruitName,
                i.QuantityKg,
                i.UnitPrice,
                i.Subtotal)),
            order.CreatedAt,
            order.UpdatedAt
        );
}