using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Entities;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Aggregates;
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
            entity.Property(i => i.Description).IsRequired().HasMaxLength(1000);
            entity.Property(i => i.EvidenceUrls).IsRequired();  // JSON string
            entity.Property(i => i.Status)
                .HasConversion<string>()
                .IsRequired();
        });
        
        builder.UseSnakeCaseNamingConvention();
    }
    
}