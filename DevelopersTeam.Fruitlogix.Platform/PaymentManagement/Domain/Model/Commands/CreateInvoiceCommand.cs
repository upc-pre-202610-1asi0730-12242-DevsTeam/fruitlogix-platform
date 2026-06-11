namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;

public record CreateInvoiceCommand(
    int ClientId,
    int? OrderId,
    decimal Amount,
    string Currency,
    DateOnly DueDate,
    string InvoiceType
);