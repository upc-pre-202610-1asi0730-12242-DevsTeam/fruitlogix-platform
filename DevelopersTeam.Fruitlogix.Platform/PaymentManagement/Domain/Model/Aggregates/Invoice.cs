using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;

public class Invoice : IAuditableEntity
{
    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public int? OrderId { get; private set; }
    public Money TotalAmount { get; private set; } = null!;
    public DueDate DueDate { get; private set; } = null!;
    public InvoiceStatus Status { get; private set; }
    public InvoiceType InvoiceType { get; private set; }
    public DateTimeOffset? IssuedAt { get; private set; }
    public DateTimeOffset? PaidAt { get; private set; }

    protected Invoice() { }

    public Invoice(CreateInvoiceCommand command)
    {
        ClientId = command.ClientId;
        OrderId = command.OrderId;
        TotalAmount = new Money(command.Amount, command.Currency);
        DueDate = new DueDate(command.DueDate);
        InvoiceType = Enum.Parse<InvoiceType>(command.InvoiceType, ignoreCase: true);
        Status = InvoiceStatus.PENDING;
        IssuedAt = DateTimeOffset.UtcNow;
    }

    public void MarkAsPaid()
    {
        if (Status == InvoiceStatus.PAID)
            throw new InvalidOperationException("Invoice is already paid.");
        Status = InvoiceStatus.PAID;
        PaidAt = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}