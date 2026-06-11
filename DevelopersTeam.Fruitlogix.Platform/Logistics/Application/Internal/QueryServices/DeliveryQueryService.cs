using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.QueryServices;

public class DeliveryQueryService : IDeliveryQueryService
{
    private readonly IDeliveryRepository _deliveryRepository;

    public DeliveryQueryService(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<IEnumerable<Delivery>> Handle(GetAllDeliveriesQuery query)
    {
        return await _deliveryRepository.ListAsync();
    }
}