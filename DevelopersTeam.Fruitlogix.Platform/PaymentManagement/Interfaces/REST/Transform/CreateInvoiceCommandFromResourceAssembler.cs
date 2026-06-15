using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;

public static class CreateInvoiceCommandFromResourceAssembler
{
    public static CreateInvoiceCommand ToCommandFromResource(CreateInvoiceResource resource) =>
        new(
            resource.ClientId,
            resource.OrderId,
            resource.Amount,
            resource.Currency,
            resource.DueDate,
            resource.InvoiceType
        );
}