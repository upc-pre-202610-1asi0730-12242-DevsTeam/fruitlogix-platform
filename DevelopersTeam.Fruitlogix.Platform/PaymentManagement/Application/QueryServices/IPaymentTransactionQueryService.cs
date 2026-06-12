using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Queries;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;

public interface IPaymentTransactionQueryService
{
    Task<IEnumerable<PaymentTransaction>> Handle(GetAllPaymentTransactionsQuery query);
}