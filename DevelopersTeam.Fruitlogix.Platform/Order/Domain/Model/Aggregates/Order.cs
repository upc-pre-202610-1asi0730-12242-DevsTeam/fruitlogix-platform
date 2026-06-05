using DevelopersTeam.Fruitlogix.Platform.Order.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Order.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.Order.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.Order.Domain.Model.Aggregates;


/// <summary>
///     Aggregate root representing a fruit distribution order.
/// </summary>
public class Order : IAuditableEntity
{
    public int Id { get; private set; }
    public int CommercialClientId { get; private set; }
    public ProducerId? ProducerId { get; private set; }  // se asigna después
    public OrderStatus Status { get; private set; }
    public DeliveryDate DeliveryDate 
    { get; private set; } = null!;
    public string? Notes { get; private set; }
    public decimal TotalAmount { get; private set; }     // calculado al agregar items
    public string? CancellationReason { get; private set; }  // si se cancela/rechaza

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Order() { }

    public Order(CreateOrderCommand command)
    {
        CommercialClientId = command.CommercialClientId;
        DeliveryDate = new DeliveryDate(command.DeliveryDate);
        Status = OrderStatus.Pending;
        Notes = command.Notes;
        TotalAmount = 0;
    }

    public void AddItem(string fruitName, int quantity, decimal unitPrice)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Solo se pueden agregar items a pedidos en estado Pendiente.");
        _items.Add(new OrderItem(fruitName, quantity, unitPrice));
        RecalculateTotal();
    }

    public void AssignProducer(int producerId)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("El productor solo puede asignarse en estado Pendiente.");
        ProducerId = new ProducerId(producerId);
        Status = OrderStatus.Managed;
    }

    public void UpdateDetails(UpdateOrderCommand command)
    {
        if (Status != OrderStatus.Pending && Status != OrderStatus.Managed)
            throw new InvalidOperationException("No se pueden editar pedidos en tránsito o entregados.");
        DeliveryDate = new DeliveryDate(command.DeliveryDate);
        Notes = command.Notes;
        RecalculateTotal();
    }

    public void MarkQualityVerified()
    {
        if (Status != OrderStatus.Managed)
            throw new InvalidOperationException("El pedido debe estar en estado Managed para verificar calidad.");
        Status = OrderStatus.QualityVerified;
    }

    public void MarkReadyForDispatch()
    {
        if (Status != OrderStatus.QualityVerified)
            throw new InvalidOperationException("El pedido debe tener calidad verificada antes del despacho.");
        Status = OrderStatus.ReadyForDispatch;
    }

    public void Dispatch()
    {
        if (Status != OrderStatus.ReadyForDispatch)
            throw new InvalidOperationException("El pedido debe estar listo para despacho.");
        Status = OrderStatus.InTransit;
    }

    public void ConfirmDelivery()
    {
        if (Status != OrderStatus.InTransit)
            throw new InvalidOperationException("El pedido debe estar en tránsito para confirmar entrega.");
        Status = OrderStatus.Delivered;
    }

    public void Cancel(string reason)
    {
        if (Status == OrderStatus.InTransit || Status == OrderStatus.Delivered)
            throw new InvalidOperationException("No se puede cancelar un pedido en tránsito o entregado.");
        CancellationReason = reason;
        Status = OrderStatus.Cancelled;
    }

    public void Reject(string reason)
    {
        if (Status != OrderStatus.Managed)
            throw new InvalidOperationException("Solo se pueden rechazar pedidos en estado Managed.");
        CancellationReason = reason;
        Status = OrderStatus.Rejected;
    }

    private void RecalculateTotal() =>
        TotalAmount = _items.Sum(i => i.Subtotal);
}