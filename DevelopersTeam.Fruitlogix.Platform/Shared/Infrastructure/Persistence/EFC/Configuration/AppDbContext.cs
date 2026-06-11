using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;
// Agregar en AppDbContext.cs — sección usings de Profiles
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Order Management
        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(o => o.CommercialClientId)
            .IsRequired();
        builder.Entity<Order>().Property(o => o.Status)
            .HasConversion<string>()
            .IsRequired();
        builder.Entity<Order>().Property(o => o.FruitType)
            .IsRequired();
        builder.Entity<Order>().Property(o => o.TotalVolume)
            .IsRequired();
        builder.Entity<Order>().Property(o => o.TotalAmount)
            .HasColumnType("decimal(12,2)")
            .IsRequired();
        builder.Entity<Order>().Property(o => o.Notes)
            .IsRequired(false);
        builder.Entity<Order>().Property(o => o.CancellationReason)
            .IsRequired(false);
        builder.Entity<Order>()
            .Property(o => o.ProducerId)
            .HasConversion(
                v => v == null ? (int?)null : v.Value,
                v => v == null ? null : new ProducerId(v.Value))
            .IsRequired(false);
        builder.Entity<Order>()
            .Property(o => o.DeliveryDueDate)
            .HasConversion(
                v => v.Value,
                v => new DeliveryDate(v))
            .IsRequired();
        builder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey("OrderId")
            .OnDelete(DeleteBehavior.Cascade);

        // Order Items
        builder.Entity<OrderItem>().HasKey(i => i.Id);
        builder.Entity<OrderItem>().Property(i => i.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OrderItem>().Property(i => i.FruitName)
            .IsRequired();
        builder.Entity<OrderItem>().Property(i => i.QuantityKg)
            .IsRequired();
        builder.Entity<OrderItem>().Property(i => i.UnitPrice)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        builder.Entity<OrderItem>().Ignore(i => i.Subtotal);
        
        //Profiles
        builder.Entity<Producer>().HasKey(p => p.Id);
        builder.Entity<Producer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Producer>().Property(p => p.ProducerType)
            .HasConversion<string>().IsRequired();

        builder.Entity<Producer>().OwnsOne(p => p.TaxId, vo =>
            vo.Property(t => t.Value).HasColumnName("tax_id").IsRequired());

        builder.Entity<Producer>().OwnsOne(p => p.ContactInfo, vo =>
        {
            vo.Property(c => c.Email).HasColumnName("email").IsRequired();
            vo.Property(c => c.Phone).HasColumnName("phone").IsRequired();
        });

        builder.Entity<Producer>().OwnsOne(p => p.Location, vo =>
        {
            vo.Property(l => l.Country).HasColumnName("country");
            vo.Property(l => l.Region).HasColumnName("region");
            vo.Property(l => l.City).HasColumnName("city");
            vo.Property(l => l.Address).HasColumnName("address");
        });

        builder.Entity<Producer>().OwnsOne(p => p.ProductionInfo, vo =>
        {
            vo.Property(pi => pi.Crop).HasColumnName("crop").IsRequired();
            vo.Property(pi => pi.CultivatedHectares).HasColumnName("cultivated_hectares");
            vo.Property(pi => pi.MonthlyProduction).HasColumnName("monthly_production");
        });

        builder.Entity<Producer>().Property(p => p.FullName).IsRequired();
        builder.Entity<Producer>().Property(p => p.LegalName).IsRequired();
        builder.Entity<Producer>().Property(p => p.Rating).IsRequired();
        builder.Entity<Producer>().Property(p => p.Certifications);
        builder.Entity<Producer>().Property(p => p.Photo);

        builder.UseSnakeCaseNamingConvention();
    }
}