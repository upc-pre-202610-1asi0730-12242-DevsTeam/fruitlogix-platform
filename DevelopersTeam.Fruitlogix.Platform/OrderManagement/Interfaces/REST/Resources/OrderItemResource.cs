namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record OrderItemResource(
    int Id,
    int ProductId,
    string ProductName,
    double QuantityKg,
    decimal UnitPrice,
    decimal Subtotal
);