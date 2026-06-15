namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Resources;

public record UpdateProducerResource(
    string    ProducerType,
    string    FullName,
    string    TaxId,
    string    LegalName,
    string    Email,
    string    Phone,
    string    Country,
    string    Region,
    string    City,
    string    Address,
    string    Crop,
    double    CultivatedHectares,
    string    MonthlyProduction,
    DateOnly? OperationsStartDate,
    string    Certifications,
    string    Photo
);