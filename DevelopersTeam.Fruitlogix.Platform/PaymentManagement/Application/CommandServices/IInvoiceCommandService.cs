using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;

public interface IInvoiceCommandService
{
    Task<Invoice?> Handle(CreateInvoiceCommand command);
}