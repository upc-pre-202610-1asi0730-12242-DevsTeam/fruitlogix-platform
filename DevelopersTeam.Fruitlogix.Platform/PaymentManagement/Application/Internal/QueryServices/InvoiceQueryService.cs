using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository invoiceRepository) : IInvoiceQueryService
{
    public async Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query) =>
        await invoiceRepository.ListAsync();
}