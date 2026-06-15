namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record UpdateOrderCommand(
    int OrderId,
    int ProducerId,
    DateOnly DeliveryDueDate,
    string FruitType,
    double TotalVolume,
    decimal TotalAmount,
    string? Notes
);