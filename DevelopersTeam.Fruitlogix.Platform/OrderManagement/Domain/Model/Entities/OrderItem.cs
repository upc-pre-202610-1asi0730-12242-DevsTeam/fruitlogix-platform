using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;

public class OrderItem : IAuditableEntity
{
    public int Id { get; private set; }
    public string FruitName { get; private set; } = null!;
    public double QuantityKg { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Subtotal => (decimal)QuantityKg * UnitPrice;

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected OrderItem() { }

    public OrderItem(string fruitName, double quantityKg, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(fruitName))
            throw new ArgumentException("Fruit name is required.");
        if (quantityKg <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero.");

        FruitName = fruitName;
        QuantityKg = quantityKg;
        UnitPrice = unitPrice;
    }
}