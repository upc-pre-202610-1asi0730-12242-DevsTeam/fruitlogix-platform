namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record OrderItemResource(
    int Id,
    string FruitName,
    double QuantityKg,
    decimal UnitPrice,
    decimal Subtotal
);