using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.CommandServices;

public class TrackingLogCommandService : ITrackingLogCommandService
{
    private readonly ITrackingLogRepository _trackingLogRepository;
    private readonly IUnitOfWork            _unitOfWork;

    public TrackingLogCommandService(
        ITrackingLogRepository trackingLogRepository,
        IUnitOfWork unitOfWork)
    {
        _trackingLogRepository = trackingLogRepository;
        _unitOfWork            = unitOfWork;
    }

    public async Task<TrackingLog> Handle(CreateTrackingLogCommand command)
    {
        var log = new TrackingLog(command);
        await _trackingLogRepository.AddAsync(log);
        await _unitOfWork.CompleteAsync();
        return log;
    }
}