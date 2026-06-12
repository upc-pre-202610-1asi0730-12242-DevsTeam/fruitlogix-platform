using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Infrastructure.Persistence.EFC.Repositories;

public class PaymentTransactionRepository(AppDbContext context)
    : BaseRepository<PaymentTransaction>(context), IPaymentTransactionRepository
{
}