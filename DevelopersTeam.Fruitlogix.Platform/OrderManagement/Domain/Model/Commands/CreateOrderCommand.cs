namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record CreateOrderCommand(
    int CommercialClientId,
    int ProducerId,
    DateOnly DeliveryDueDate,
    string FruitType,
    double TotalVolume,
    decimal TotalAmount,
    string? Notes,
    List<CreateOrderItemCommand> Items
);

public record CreateOrderItemCommand(
    string FruitName,
    double QuantityKg,
    decimal UnitPrice
);