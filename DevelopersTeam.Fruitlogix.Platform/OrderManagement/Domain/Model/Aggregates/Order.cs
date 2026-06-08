using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;

public class Order : IAuditableEntity
{
    public int Id { get; private set; }
    public int CommercialClientId { get; private set; }
    public ProducerId? ProducerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DeliveryDate DeliveryDueDate { get; private set; } = null!;
    public string FruitType { get; private set; } = null!;
    public double TotalVolume { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string? Notes { get; private set; }
    public string? CancellationReason { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Order() { }

    public Order(CreateOrderCommand command)
    {
        CommercialClientId = command.CommercialClientId;
        ProducerId = new ProducerId(command.ProducerId);
        DeliveryDueDate = new DeliveryDate(command.DeliveryDueDate);
        FruitType = command.FruitType;
        TotalVolume = command.TotalVolume;
        TotalAmount = command.TotalAmount;
        Notes = command.Notes;
        Status = OrderStatus.Pending;

        foreach (var item in command.Items)
            _items.Add(new OrderItem(item.FruitName, item.QuantityKg, item.UnitPrice));
    }

    public void AssignProducer(AssignProducerCommand command)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Producer can only be assigned to pending orders.");
        ProducerId = new ProducerId(command.ProducerId);
        Status = OrderStatus.InPreparation;
    }

    public void UpdateDetails(UpdateOrderCommand command)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be edited.");
        ProducerId = new ProducerId(command.ProducerId);
        DeliveryDueDate = new DeliveryDate(command.DeliveryDueDate);
        FruitType = command.FruitType;
        TotalVolume = command.TotalVolume;
        TotalAmount = command.TotalAmount;
        Notes = command.Notes;
    }

    public void MarkInTransit()
    {
        if (Status != OrderStatus.InPreparation)
            throw new InvalidOperationException("Order must be in preparation to mark as in transit.");
        Status = OrderStatus.InTransit;
    }

    public void MarkDelivered()
    {
        if (Status != OrderStatus.InTransit)
            throw new InvalidOperationException("Order must be in transit to mark as delivered.");
        Status = OrderStatus.Delivered;
    }

    public void Cancel(CancelOrderCommand command)
    {
        if (Status is OrderStatus.Delivered or OrderStatus.InTransit)
            throw new InvalidOperationException("Cannot cancel an order that is in transit or delivered.");
        CancellationReason = command.Reason;
        Status = OrderStatus.Cancelled;
    }

    public void Reject(string reason)
    {
        if (Status != OrderStatus.InPreparation)
            throw new InvalidOperationException("Only orders in preparation can be rejected.");
        CancellationReason = reason;
        Status = OrderStatus.Rejected;
    }
}