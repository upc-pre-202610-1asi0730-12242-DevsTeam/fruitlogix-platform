namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record OrderResource(
    int Id,
    int CommercialClientId,
    int? ProducerId,
    string Status,
    DateOnly DeliveryDueDate,
    string DeliveryAddress,
    decimal TotalAmount,
    string? Notes,
    string? CancellationReason,
    List<OrderItemResource> Items,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);