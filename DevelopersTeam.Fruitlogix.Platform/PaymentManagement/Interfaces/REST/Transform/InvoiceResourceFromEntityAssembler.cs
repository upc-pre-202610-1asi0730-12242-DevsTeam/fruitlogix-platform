using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;

public static class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Invoice entity) =>
        new(
            entity.Id,
            entity.ClientId,
            entity.OrderId,
            entity.TotalAmount.Amount,
            entity.TotalAmount.Currency,
            entity.DueDate.Value,
            entity.Status.ToString(),
            entity.InvoiceType.ToString(),
            entity.IssuedAt,
            entity.PaidAt
        );
}