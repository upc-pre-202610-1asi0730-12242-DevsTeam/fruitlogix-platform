using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;

public class Alert : IAuditableEntity
{
    public int           Id         { get; private set; }
    public int           DeliveryId { get; private set; }
    public AlertType     Type       { get; private set; }
    public AlertSeverity Severity   { get; private set; }
    public string        Message    { get; private set; } = null!;
    public bool          IsResolved { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Alert() { }

    public Alert(CreateAlertCommand command)
    {
        DeliveryId = command.DeliveryId;
        Type       = command.Type;
        Severity   = command.Severity;
        Message    = command.Message;
        IsResolved = false;
    }

    public void Resolve()
    {
        if (IsResolved)
            throw new InvalidOperationException("Alert is already resolved.");
        IsResolved = true;
    }
}