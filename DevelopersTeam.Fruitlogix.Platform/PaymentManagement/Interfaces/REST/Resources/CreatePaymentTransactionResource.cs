namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

public record CreatePaymentTransactionResource(
    int InvoiceId,
    decimal Amount,
    string Currency,
    string Method,
    string Gateway,
    string GatewayRef,
    string? CardEnding,
    string? CardBrand
);