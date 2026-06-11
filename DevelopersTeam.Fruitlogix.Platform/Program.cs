using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
// Agregar en Program.cs — sección usings de Profiles
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);   

// ── Database ──────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

// ── Shared ────────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ── Order Management ──────────────────────────────────────────────────────────
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

// Profiles BC
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IProducerCommandService, ProducerCommandService>();
builder.Services.AddScoped<IProducerQueryService, ProducerQueryService>();

// Quality Control BC

// Registrar repositorio e implementación del command service de QualityControl
builder.Services.AddScoped<IHarvestBatchRepository, HarvestBatchRepository>();
builder.Services.AddScoped<IHarvestBatchCommandService, HarvestBatchCommandService>();
builder.Services.AddScoped<IHarvestBatchQueryService, HarvestBatchQueryService>();

builder.Services.AddScoped<IQualityInspectionRepository, QualityInspectionRepository>();
builder.Services.AddScoped<IQualityInspectionCommandService, QualityInspectionCommandService>();
builder.Services.AddScoped<IQualityInspectionQueryService, QualityInspectionQueryService>();

builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IIncidentCommandService, IncidentCommandService>();
builder.Services.AddScoped<IIncidentQueryService, IncidentQueryService>();

// Logistics
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryCommandService, DeliveryCommandService>();
builder.Services.AddScoped<IDeliveryQueryService, DeliveryQueryService>();
builder.Services.AddScoped<ITrackingLogRepository, TrackingLogRepository>();
builder.Services.AddScoped<ITrackingLogCommandService, TrackingLogCommandService>();
builder.Services.AddScoped<ITrackingLogQueryService, TrackingLogQueryService>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();
builder.Services.AddScoped<IAlertQueryService, AlertQueryService>();

// ── Controllers ───────────────────────────────────────────────────────────────
builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// ── Swagger ───────────────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── CORS ──────────────────────────────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
                "http://localhost:5173",   // Vue dev server
                "http://localhost:4173",   // Vue preview
                "https://fruitlogix.vercel.app") // Producción
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// ── Migrations automáticas ────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ── Middleware ────────────────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();