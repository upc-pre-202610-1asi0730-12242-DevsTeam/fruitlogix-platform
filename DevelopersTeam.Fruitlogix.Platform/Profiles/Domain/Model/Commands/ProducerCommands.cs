namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Commands;

public record CreateProducerCommand(
    string ProducerType,
    string FullName,
    string TaxId,
    string LegalName,
    string Email,
    string Phone,
    string Country,
    string Region,
    string City,
    string Address,
    string Crop,
    double CultivatedHectares,
    string MonthlyProduction,
    DateOnly? OperationsStartDate,
    string Certifications,
    string Photo
);