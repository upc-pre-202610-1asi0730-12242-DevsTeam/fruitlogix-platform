using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Infrastructure.Persistence.EFC.Repositories;
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
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.Acl;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.Internal.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.Internal.OutboundServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.Internal.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Hashing.BCrypt.Services;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Pipeline.Middleware.Extensions;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Tokens.Jwt.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Tokens.Jwt.Services;
using DevelopersTeam.Fruitlogix.Platform.Iam.Interfaces.Acl;
using Microsoft.OpenApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);   

// ── Database ──────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

// ── Shared ────────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<DevelopersTeam.Fruitlogix.Platform.Shared.Interfaces.Rest.ProblemDetails.ProblemDetailsFactory>();
// ── Order Management ──────────────────────────────────────────────────────────
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

// ── Profiles BC ───────────────────────────────────────────────────────────────
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IProducerCommandService, ProducerCommandService>();
builder.Services.AddScoped<IProducerQueryService, ProducerQueryService>();

// ── Quality Control BC ────────────────────────────────────────────────────────
builder.Services.AddScoped<IHarvestBatchRepository, HarvestBatchRepository>();
builder.Services.AddScoped<IHarvestBatchCommandService, HarvestBatchCommandService>();
builder.Services.AddScoped<IHarvestBatchQueryService, HarvestBatchQueryService>();
builder.Services.AddScoped<IQualityInspectionRepository, QualityInspectionRepository>();
builder.Services.AddScoped<IQualityInspectionCommandService, QualityInspectionCommandService>();
builder.Services.AddScoped<IQualityInspectionQueryService, QualityInspectionQueryService>();
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IIncidentCommandService, IncidentCommandService>();
builder.Services.AddScoped<IIncidentQueryService, IncidentQueryService>();

// ── Logistics ─────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryCommandService, DeliveryCommandService>();
builder.Services.AddScoped<IDeliveryQueryService, DeliveryQueryService>();
builder.Services.AddScoped<ITrackingLogRepository, TrackingLogRepository>();
builder.Services.AddScoped<ITrackingLogCommandService, TrackingLogCommandService>();
builder.Services.AddScoped<ITrackingLogQueryService, TrackingLogQueryService>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();
builder.Services.AddScoped<IAlertQueryService, AlertQueryService>();

// ── Payment ───────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceCommandService, InvoiceCommandService>();
builder.Services.AddScoped<IInvoiceQueryService, InvoiceQueryService>();
builder.Services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
builder.Services.AddScoped<IPaymentTransactionCommandService, PaymentTransactionCommandService>();
builder.Services.AddScoped<IPaymentTransactionQueryService, PaymentTransactionQueryService>();

// ── IoTInfrastructure ─────────────────────────────────────────────────────────
builder.Services.AddScoped<IIoTDeviceRepository, IoTDeviceRepository>();
builder.Services.AddScoped<IIoTDeviceQueryService, IoTDeviceQueryService>();
builder.Services.AddScoped<IIoTDeviceCommandService, IoTDeviceCommandService>();
builder.Services.AddScoped<ISensorReadingRepository, SensorReadingRepository>();
builder.Services.AddScoped<ISensorReadingCommandService, SensorReadingCommandService>();
builder.Services.AddScoped<ISensorReadingQueryService, SensorReadingQueryService>();
builder.Services.AddScoped<IAlertRuleRepository, AlertRuleRepository>();
builder.Services.AddScoped<IAlertRuleCommandService, AlertRuleCommandService>();
builder.Services.AddScoped<IAlertRuleQueryService, AlertRuleQueryService>();

// ── Messaging ─────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IConversationCommandService, ConversationCommandService>();
builder.Services.AddScoped<IMessageCommandService, MessageCommandService>();
builder.Services.AddScoped<IMessageQueryService, MessageQueryService>();
builder.Services.AddScoped<IConversationQueryService, ConversationQueryService>();

//  ── IAM (Identity and Access Management) ──────────────────────────────────
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// ── Controllers ───────────────────────────────────────────────────────────────
builder.Services.AddControllers(options =>
        options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
    });

// ── Swagger con Soporte para Tokens JWT ───────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        { new OpenApiSecuritySchemeReference("Bearer", document), new List<string>() }
    });
});

// ── CORS ──────────────────────────────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
                "http://localhost:5173",   
                "http://localhost:4173",   
                "https://fruitlogix.vercel.app", 
                "https://fruitlogixweb.web.app"  
            ) 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// ── Localización (Traducciones y Errores del Profesor) ────────────────────────
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSingleton<
    Microsoft.Extensions.Localization.IStringLocalizer<DevelopersTeam.Fruitlogix.Platform.Resources.Errors.ErrorMessages>, 
    Microsoft.Extensions.Localization.StringLocalizer<DevelopersTeam.Fruitlogix.Platform.Resources.Errors.ErrorMessages>>();

builder.Services.AddSingleton<
    Microsoft.Extensions.Localization.IStringLocalizer<DevelopersTeam.Fruitlogix.Platform.Resources.Shared.CommonMessages>, 
    Microsoft.Extensions.Localization.StringLocalizer<DevelopersTeam.Fruitlogix.Platform.Resources.Shared.CommonMessages>>();


var app = builder.Build();

// ── Migrations automáticas ────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ── Middleware ────────────────────────────────────────────────────────────────
app.UseSwagger(); 
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

// MIDDLEWARE DE AUTENTICACIÓN IAM
app.UseRequestAuthorization();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();