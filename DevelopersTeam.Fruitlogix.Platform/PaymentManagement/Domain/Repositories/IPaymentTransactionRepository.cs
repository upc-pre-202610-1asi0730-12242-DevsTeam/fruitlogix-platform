using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;

public interface IPaymentTransactionRepository : IBaseRepository<PaymentTransaction>
{
}