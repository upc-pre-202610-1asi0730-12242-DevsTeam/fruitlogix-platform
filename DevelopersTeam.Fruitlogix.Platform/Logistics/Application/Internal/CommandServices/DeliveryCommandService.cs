using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.CommandServices;

public class DeliveryCommandService : IDeliveryCommandService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IUnitOfWork         _unitOfWork;

    public DeliveryCommandService(
        IDeliveryRepository deliveryRepository,
        IUnitOfWork unitOfWork)
    {
        _deliveryRepository = deliveryRepository;
        _unitOfWork         = unitOfWork;
    }

    public async Task<Delivery> Handle(CreateDeliveryCommand command)
    {
        var delivery = new Delivery(command);
        await _deliveryRepository.AddAsync(delivery);
        await _unitOfWork.CompleteAsync();
        return delivery;
    }
}