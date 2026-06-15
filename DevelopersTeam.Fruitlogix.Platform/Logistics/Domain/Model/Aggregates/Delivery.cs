using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;

public class Delivery : IAuditableEntity
{
    public int    Id                      { get; private set; }
    public int    OrderId                 { get; private set; }
    public DriverInfo  Driver             { get; private set; } = null!;
    public VehicleInfo Vehicle            { get; private set; } = null!;
    public RouteInfo   Route              { get; private set; } = null!;
    public DateTime    EstimatedTimeOfArrival { get; private set; }
    public DeliveryStatus CurrentStatus   { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    // Constructor vacío para EF Core
    protected Delivery() { }

    public Delivery(CreateDeliveryCommand command)
    {
        OrderId                = command.OrderId;
        Driver                 = new DriverInfo(command.DriverName, command.DriverPhone);
        Vehicle                = new VehicleInfo(command.VehiclePlate, command.VehicleType);
        Route                  = new RouteInfo(command.RouteOrigin, command.RouteDestination, command.RouteDistanceKm);
        EstimatedTimeOfArrival = command.EstimatedTimeOfArrival;
        CurrentStatus          = DeliveryStatus.PendingDispatch;
    }

    public void UpdateStatus(DeliveryStatus newStatus)
    {
        CurrentStatus = newStatus;
    }
    
    public string? DelayReason { get; private set; }

    public void StartDispatch()
    {
        if (CurrentStatus != DeliveryStatus.PendingDispatch)
            throw new InvalidOperationException("Delivery must be in PendingDispatch to start.");
        CurrentStatus = DeliveryStatus.InTransit;
    }

    public void ReportDelay(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Delay reason is required.");
        CurrentStatus = DeliveryStatus.Delayed;
        DelayReason   = reason.Trim();
    }
}