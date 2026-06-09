namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record OrderResource(
    int Id,
    int CommercialClientId,
    int? ProducerId,
    string Status,
    DateOnly DeliveryDueDate,
    string FruitType,
    double TotalVolume,
    decimal TotalAmount,
    string? Notes,
    string? CancellationReason,
    IEnumerable<OrderItemResource> Items,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);