using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.QueryServices;

public class PaymentTransactionQueryService(
    IPaymentTransactionRepository paymentTransactionRepository) : IPaymentTransactionQueryService
{
    public async Task<IEnumerable<PaymentTransaction>> Handle(
        GetAllPaymentTransactionsQuery query) =>
        await paymentTransactionRepository.ListAsync();
}