using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;

public class IoTDevice : IAuditableEntity
{
    public int Id { get; private set; }
    public DeviceCode DeviceCode { get; private set; } = null!;
    public DeviceType DeviceType { get; private set; }
    public string Location { get; private set; } = string.Empty;
    public DeviceStatus Status { get; private set; }
    public DateTimeOffset? LastReadingAt { get; private set; }

    // IAuditableEntity
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected IoTDevice() { } // EF Core

    public IoTDevice(string deviceCode, DeviceType deviceType, string location)
    {
        DeviceCode = new DeviceCode(deviceCode);
        DeviceType = deviceType;
        Location = location;
        Status = DeviceStatus.Offline;
    }

    public void Calibrate()
    {
        if (Status == DeviceStatus.Maintenance)
            throw new InvalidOperationException("Device is already under maintenance.");
        Status = DeviceStatus.Maintenance;
    }

    public void Activate()
    {
        Status = DeviceStatus.Active;
    }

    public void RegisterLastReading()
    {
        LastReadingAt = DateTimeOffset.UtcNow;
    }
}