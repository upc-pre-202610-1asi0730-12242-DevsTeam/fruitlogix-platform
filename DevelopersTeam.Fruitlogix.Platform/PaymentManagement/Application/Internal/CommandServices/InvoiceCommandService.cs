using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.CommandServices;

public class InvoiceCommandService(
    IInvoiceRepository invoiceRepository,
    IUnitOfWork unitOfWork) : IInvoiceCommandService
{
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {
        var invoice = new Invoice(command);
        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.CompleteAsync();
        return invoice;
    }
}