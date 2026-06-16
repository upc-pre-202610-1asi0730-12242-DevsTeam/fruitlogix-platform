namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record CreateOrderResource(
    int CommercialClientId,
    DateOnly DeliveryDueDate,
    string DeliveryAddress,
    decimal TotalAmount,
    string? Notes,
    List<CreateOrderItemResource> Items
);

public record CreateOrderItemResource(
    int ProductId,
    string ProductName,
    double QuantityKg,
    decimal UnitPrice,
    decimal Subtotal
);