using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.CommandServices;

public class PaymentTransactionCommandService(
    IPaymentTransactionRepository transactionRepository,
    IInvoiceRepository invoiceRepository,
    IUnitOfWork unitOfWork) : IPaymentTransactionCommandService
{
    public async Task<PaymentTransaction?> Handle(CreatePaymentTransactionCommand command)
    {
        var invoice = await invoiceRepository.FindByIdAsync(command.InvoiceId);
        if (invoice is null) return null;

        var transaction = new PaymentTransaction(command);
        await transactionRepository.AddAsync(transaction);

        transaction.MarkAsSuccess();
        invoice.MarkAsPaid();

        await unitOfWork.CompleteAsync();
        return transaction;
    }
}