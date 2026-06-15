namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record UpdateOrderResource(
    int ProducerId,
    DateOnly DeliveryDueDate,
    string FruitType,
    double TotalVolume,
    decimal TotalAmount,
    string? Notes
);