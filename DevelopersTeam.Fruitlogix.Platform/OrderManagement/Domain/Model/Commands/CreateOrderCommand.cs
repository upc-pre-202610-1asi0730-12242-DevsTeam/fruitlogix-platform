namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record CreateOrderCommand(
    int CommercialClientId,
    DateOnly DeliveryDueDate,
    string DeliveryAddress,
    decimal TotalAmount,
    string? Notes,   
    List<CreateOrderItemCommand> Items 
);

public record CreateOrderItemCommand(
    int ProductId,      
    string ProductName,  
    double QuantityKg,  
    decimal UnitPrice,
    decimal Subtotal
);