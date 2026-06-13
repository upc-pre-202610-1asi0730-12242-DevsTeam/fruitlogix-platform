using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Entities;

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

        builder.Entity<Producer>().Property(p => p.FullName).IsRequired();
        builder.Entity<Producer>().Property(p => p.LegalName).IsRequired();
        builder.Entity<Producer>().Property(p => p.Rating).IsRequired();
        builder.Entity<Producer>().Property(p => p.Certifications);
        builder.Entity<Producer>().Property(p => p.Photo);

        builder.Entity<Producer>().OwnsOne(p => p.TaxId, vo =>
        {
            vo.Property(t => t.Value).HasColumnName("tax_id").IsRequired();
            vo.WithOwner().HasForeignKey("Id");
        });

        builder.Entity<Producer>().OwnsOne(p => p.ContactInfo, vo =>
        {
            vo.Property(c => c.Email).HasColumnName("email").IsRequired();
            vo.Property(c => c.Phone).HasColumnName("phone").IsRequired();
            vo.WithOwner().HasForeignKey("Id");
        });

        builder.Entity<Producer>().OwnsOne(p => p.Location, vo =>
        {
            vo.Property(l => l.Country).HasColumnName("country");
            vo.Property(l => l.Region).HasColumnName("region");
            vo.Property(l => l.City).HasColumnName("city");
            vo.Property(l => l.Address).HasColumnName("address");
            vo.WithOwner().HasForeignKey("Id");
        });
        

        builder.Entity<Producer>().OwnsOne(p => p.ProductionInfo, vo =>
        {
            vo.Property(pi => pi.Crop).HasColumnName("crop").IsRequired();
            vo.Property(pi => pi.CultivatedHectares).HasColumnName("cultivated_hectares");
            vo.Property(pi => pi.MonthlyProduction).HasColumnName("monthly_production");
            vo.WithOwner().HasForeignKey("Id");
        });

        builder.Entity<HarvestBatch>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(b => b.FruitType).IsRequired().HasMaxLength(100);
            entity.Property(b => b.QuantityKg).IsRequired();
            entity.Property(b => b.HarvestDate).IsRequired();
            entity.Property(b => b.Status)
                .HasConversion<string>() // guarda "Pending", "Approved", etc.
                .IsRequired();
        }); 
        
        builder.Entity<QualityInspection>(entity =>
        {
            entity.HasKey(q => q.Id);
            entity.Property(q => q.Notes).HasMaxLength(500);

            entity.HasOne(q => q.VisualInspection)
                .WithOne()
                .HasForeignKey<VisualInspection>(v => v.QualityInspectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_quality_inspections_visual"); // Nombre corto y seguro

            entity.HasOne(q => q.TechnicalParameters)
                .WithOne()
                .HasForeignKey<TechnicalParameters>(t => t.QualityInspectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_quality_inspections_technical"); // Nombre corto y seguro
    
            entity.HasOne(q => q.PreparationChecklist)
                .WithOne()
                .HasForeignKey<PreparationChecklist>(c => c.QualityInspectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_quality_inspections_preparation"); // Nombre corto y seguro
        });

        builder.Entity<VisualInspection>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.Property(v => v.WastePercentage).IsRequired();
            entity.Property(v => v.AppearanceRating).IsRequired();
        });

        builder.Entity<TechnicalParameters>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.TemperatureCelsius).IsRequired();
            entity.Property(t => t.HumidityPercent).IsRequired();
            entity.Property(t => t.Ph).IsRequired();
            entity.Property(t => t.BrixDegrees).IsRequired();
        });

        builder.Entity<PreparationChecklist>(entity =>
        {
            entity.HasKey(c => c.Id);
        });
        
        builder.Entity<Incident>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(i => i.BatchId).IsRequired();
            entity.Property(i => i.Description).IsRequired().HasMaxLength(1000);
            entity.Property(i => i.EvidenceUrls).IsRequired();

            entity.Property(i => i.Status)
                .HasConversion<string>()
                .IsRequired();

            entity.Property(i => i.ResolvedAt);
        });
        // Delivery
        builder.Entity<Delivery>().HasKey(d => d.Id);
        builder.Entity<Delivery>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Delivery>().Property(d => d.OrderId).IsRequired();
        builder.Entity<Delivery>().Property(d => d.EstimatedTimeOfArrival).IsRequired();
        builder.Entity<Delivery>().Property(d => d.CurrentStatus)
            .HasConversion<string>().IsRequired();

// Value Object: DriverInfo
        builder.Entity<Delivery>().OwnsOne(d => d.Driver, nav =>
        {
            nav.Property(x => x.Name).HasColumnName("driver_name").IsRequired();
            nav.Property(x => x.Phone).HasColumnName("driver_phone");
            nav.WithOwner().HasForeignKey("Id"); 
        });

// Value Object: VehicleInfo
        builder.Entity<Delivery>().OwnsOne(d => d.Vehicle, nav =>
        {
            nav.Property(x => x.Plate).HasColumnName("vehicle_plate").IsRequired();
            nav.Property(x => x.Type).HasColumnName("vehicle_type");
            nav.WithOwner().HasForeignKey("Id"); 
        });

// Value Object: RouteInfo
        builder.Entity<Delivery>().OwnsOne(d => d.Route, nav =>
        {
            nav.Property(x => x.Origin).HasColumnName("route_origin").IsRequired();
            nav.Property(x => x.Destination).HasColumnName("route_destination").IsRequired();
            nav.Property(x => x.DistanceKm).HasColumnName("route_distance_km").IsRequired();
            nav.WithOwner().HasForeignKey("Id"); 
        }); 
        builder.Entity<Delivery>().Property(d => d.DelayReason);

        builder.Entity<TrackingLog>().HasKey(t => t.Id);
        builder.Entity<TrackingLog>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TrackingLog>().Property(t => t.DeliveryId).IsRequired();
        builder.Entity<TrackingLog>().Property(t => t.Timestamp).IsRequired();
        builder.Entity<TrackingLog>().Property(t => t.Temperature).IsRequired();
        builder.Entity<TrackingLog>().Property(t => t.Humidity).IsRequired();

        builder.Entity<TrackingLog>().OwnsOne(t => t.Location, nav =>
        {
            nav.Property(x => x.Latitude).HasColumnName("latitude").IsRequired();
            nav.Property(x => x.Longitude).HasColumnName("longitude").IsRequired();
            nav.WithOwner().HasForeignKey("Id");
        });
        
        builder.Entity<Alert>().HasKey(a => a.Id);
        builder.Entity<Alert>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alert>().Property(a => a.DeliveryId).IsRequired();
        builder.Entity<Alert>().Property(a => a.Type).HasConversion<string>().IsRequired();
        builder.Entity<Alert>().Property(a => a.Severity).HasConversion<string>().IsRequired();
        builder.Entity<Alert>().Property(a => a.Message).IsRequired();
        builder.Entity<Alert>().Property(a => a.IsResolved).IsRequired();
        
        builder.Entity<Invoice>().HasKey(i => i.Id);
        builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invoice>().Property(i => i.ClientId).IsRequired();
        builder.Entity<Invoice>().Property(i => i.OrderId).IsRequired(false);

        builder.Entity<Invoice>().OwnsOne(i => i.TotalAmount, money =>
        {
            money.WithOwner().HasForeignKey("Id");
            money.Property(m => m.Amount).HasColumnName("total_amount").IsRequired();
            money.Property(m => m.Currency).HasColumnName("currency").HasMaxLength(3).IsRequired();
        });

        builder.Entity<Invoice>()
            .Property(i => i.DueDate)
            .HasConversion(v => v.Value, v => new DueDate(v))
            .IsRequired();

        builder.Entity<Invoice>().Property(i => i.Status).HasConversion<string>().IsRequired();
        builder.Entity<Invoice>().Property(i => i.InvoiceType).HasConversion<string>().IsRequired();
        builder.Entity<Invoice>().Property(i => i.IssuedAt).IsRequired(false);
        builder.Entity<Invoice>().Property(i => i.PaidAt).IsRequired(false);
        
        builder.Entity<PaymentTransaction>().HasKey(t => t.Id);
        builder.Entity<PaymentTransaction>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentTransaction>().Property(t => t.InvoiceId).IsRequired();
        builder.Entity<PaymentTransaction>().Property(t => t.GatewayRef).IsRequired().HasMaxLength(100);
        builder.Entity<PaymentTransaction>().Property(t => t.ProcessedAt).IsRequired();

        builder.Entity<PaymentTransaction>().OwnsOne(t => t.Amount, money =>
        {
            money.WithOwner().HasForeignKey("Id");
            money.Property(m => m.Amount).HasColumnName("amount").IsRequired();
            money.Property(m => m.Currency).HasColumnName("currency").HasMaxLength(3).IsRequired();
        });

        builder.Entity<PaymentTransaction>().OwnsOne(t => t.CardDetails, card =>
        {
            card.WithOwner().HasForeignKey("Id");
            card.Property(c => c.CardEnding).HasColumnName("card_ending").HasMaxLength(4).IsRequired(false);
            card.Property(c => c.CardBrand).HasColumnName("card_brand").HasMaxLength(20).IsRequired(false);
        });

        builder.Entity<PaymentTransaction>().Property(t => t.Method).HasConversion<string>().IsRequired();
        builder.Entity<PaymentTransaction>().Property(t => t.Gateway).HasConversion<string>().IsRequired();
        builder.Entity<PaymentTransaction>().Property(t => t.Status).HasConversion<string>().IsRequired();
        
        // IotInfrastructure

        builder.Entity<IoTDevice>().HasKey(d => d.Id);
        builder.Entity<IoTDevice>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<IoTDevice>().OwnsOne(d => d.DeviceCode, dc =>
        {
            dc.WithOwner().HasForeignKey("Id");
            dc.Property(v => v.Value).HasColumnName("device_code").IsRequired();
        });

        builder.Entity<IoTDevice>()
            .Property(d => d.DeviceType)
            .HasConversion<string>()
            .IsRequired();

        builder.Entity<IoTDevice>()
            .Property(d => d.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Entity<IoTDevice>()
            .Property(d => d.Location)
            .IsRequired();

        builder.Entity<IoTDevice>()
            .Property(d => d.LastReadingAt)
            .IsRequired(false);
        
        builder.Entity<SensorReading>().HasKey(r => r.Id);
        builder.Entity<SensorReading>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SensorReading>().Property(r => r.DeviceId).IsRequired();
        builder.Entity<SensorReading>().Property(r => r.Timestamp).IsRequired();

        builder.Entity<SensorReading>().OwnsOne(r => r.Reading, rv =>
        {
            rv.WithOwner().HasForeignKey("Id");
            rv.Property(v => v.Value).HasColumnName("value").IsRequired();
            rv.Property(v => v.Unit).HasColumnName("unit").IsRequired();
        });
        
        builder.UseSnakeCaseNamingConvention();
    }
    
}