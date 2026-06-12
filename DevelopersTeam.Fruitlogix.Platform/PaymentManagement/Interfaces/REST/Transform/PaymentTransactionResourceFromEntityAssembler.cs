using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;

public static class PaymentTransactionResourceFromEntityAssembler
{
    public static PaymentTransactionResource ToResourceFromEntity(PaymentTransaction entity) =>
        new(
            entity.Id,
            entity.InvoiceId,
            entity.Amount.Amount,
            entity.Amount.Currency,
            entity.Method.ToString(),
            entity.Gateway.ToString(),
            entity.GatewayRef,
            entity.Status.ToString(),
            entity.CardDetails?.CardEnding,
            entity.CardDetails?.CardBrand,
            entity.ProcessedAt
        );
}