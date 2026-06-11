namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

public record InvoiceResource(
    int Id,
    int ClientId,
    int? OrderId,
    decimal TotalAmount,
    string Currency,
    DateOnly DueDate,
    string Status,
    string InvoiceType,
    DateTimeOffset? IssuedAt,
    DateTimeOffset? PaidAt
);