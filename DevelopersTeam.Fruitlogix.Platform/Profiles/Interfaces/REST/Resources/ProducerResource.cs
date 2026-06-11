namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Resources;

public record ProducerResource(
    int     Id,
    string  ProducerType,
    string  FullName,
    string  TaxId,
    string  LegalName,
    string  Email,
    string  Phone,
    string  Country,
    string  Region,
    string  City,
    string  Address,
    string  Crop,
    double  CultivatedHectares,
    string  MonthlyProduction,
    DateOnly? OperationsStartDate,
    double  Rating,
    string  Certifications,
    string  Photo
);