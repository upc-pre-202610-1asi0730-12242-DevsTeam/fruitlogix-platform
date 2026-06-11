namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

public record CreateInvoiceResource(
    int ClientId,
    int? OrderId,
    decimal Amount,
    string Currency,
    DateOnly DueDate,
    string InvoiceType
);