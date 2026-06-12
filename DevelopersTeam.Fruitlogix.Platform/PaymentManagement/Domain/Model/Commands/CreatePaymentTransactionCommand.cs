namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;

public record CreatePaymentTransactionCommand(
    int InvoiceId,
    decimal Amount,
    string Currency,
    string Method,
    string Gateway,
    string GatewayRef,
    string? CardEnding,
    string? CardBrand
);