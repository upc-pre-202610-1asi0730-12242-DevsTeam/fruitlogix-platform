using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;

public class PaymentTransaction : IAuditableEntity
{
    public int Id { get; private set; }
    public int InvoiceId { get; private set; }
    public Money Amount { get; private set; } = null!;
    public PaymentMethod Method { get; private set; }
    public PaymentGateway Gateway { get; private set; }
    public string GatewayRef { get; private set; } = null!;
    public TransactionStatus Status { get; private set; }
    public CardDetails? CardDetails { get; private set; }
    public DateTimeOffset ProcessedAt { get; private set; }

    protected PaymentTransaction() { }

    public PaymentTransaction(CreatePaymentTransactionCommand command)
    {
        InvoiceId = command.InvoiceId;
        Amount = new Money(command.Amount, command.Currency);
        Method = Enum.Parse<PaymentMethod>(command.Method, ignoreCase: true);
        Gateway = Enum.Parse<PaymentGateway>(command.Gateway, ignoreCase: true);
        GatewayRef = command.GatewayRef;
        Status = TransactionStatus.PENDING;
        ProcessedAt = DateTimeOffset.UtcNow;

        if (!string.IsNullOrWhiteSpace(command.CardEnding) &&
            !string.IsNullOrWhiteSpace(command.CardBrand))
            CardDetails = new CardDetails(command.CardEnding, command.CardBrand);
    }

    public void MarkAsSuccess() => Status = TransactionStatus.SUCCESS;
    public void MarkAsFailed()  => Status = TransactionStatus.FAILED;

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}