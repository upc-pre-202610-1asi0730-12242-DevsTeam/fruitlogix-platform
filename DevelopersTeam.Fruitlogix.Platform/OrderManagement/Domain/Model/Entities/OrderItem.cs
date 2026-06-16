using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;

public class OrderItem : IAuditableEntity
{
    public int Id { get; private set; }
    
    public int ProductId { get; private set; } 
    
    public string ProductName { get; private set; } = null!;
    
    public double QuantityKg { get; private set; }
    public decimal UnitPrice { get; private set; }
    
    public decimal Subtotal { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected OrderItem() { }

    public OrderItem(int productId, string productName, double quantityKg, decimal unitPrice, decimal subtotal)
    {
        if (productId <= 0)
            throw new ArgumentException("Product ID must be greater than zero.");
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name is required.");
        if (quantityKg <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero.");
        if (subtotal <= 0)
            throw new ArgumentException("Subtotal must be greater than zero.");

        ProductId = productId;
        ProductName = productName;
        QuantityKg = quantityKg;
        UnitPrice = unitPrice;
        Subtotal = subtotal;
    }
}