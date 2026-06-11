using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.ValueObjects;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model;
namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;

public class Producer : IAuditableEntity
{
    public int    Id                  { get; private set; }
    public DateTimeOffset? CreatedAt  { get; set; }
    public DateTimeOffset? UpdatedAt  { get; set; }

    public ProducerType   ProducerType        { get; private set; }
    public string         FullName            { get; private set; }
    public TaxId          TaxId               { get; private set; }
    public string         LegalName           { get; private set; }
    public ContactInfo    ContactInfo         { get; private set; }
    public Location       Location            { get; private set; }
    public ProductionInfo ProductionInfo      { get; private set; }
    public DateOnly?      OperationsStartDate { get; private set; }
    public double         Rating              { get; private set; }
    public string         Certifications      { get; private set; }
    public string         Photo               { get; private set; }

    // Constructor vacío requerido por EF Core
    protected Producer() { }

    public Producer(CreateProducerCommand command)
    {
        ProducerType        = Enum.Parse<ProducerType>(command.ProducerType, ignoreCase: true);
        FullName            = command.FullName;
        TaxId               = new TaxId(command.TaxId);
        LegalName           = command.LegalName;
        ContactInfo         = new ContactInfo(command.Email, command.Phone);
        Location            = new Location(command.Country, command.Region, command.City, command.Address);
        ProductionInfo      = new ProductionInfo(command.Crop, command.CultivatedHectares, command.MonthlyProduction);
        OperationsStartDate = command.OperationsStartDate;
        Rating              = 0.0;   // siempre inicializado aquí, nunca desde fuera
        Certifications      = command.Certifications ?? string.Empty;
        Photo               = command.Photo ?? string.Empty;
    }
}