namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record CreateOrderResource(
    int CommercialClientId,
    int ProducerId,
    DateOnly DeliveryDueDate,
    string FruitType,
    double TotalVolume,
    decimal TotalAmount,
    string? Notes,
    List<CreateOrderItemResource> Items
);

public record CreateOrderItemResource(
    string FruitName,
    double QuantityKg,
    decimal UnitPrice
);