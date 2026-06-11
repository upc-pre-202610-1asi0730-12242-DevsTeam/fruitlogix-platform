using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Transform;

public static class ProducerResourceAssembler
{
    public static CreateProducerCommand ToCommandFromResource(CreateProducerResource resource) =>
        new(
            resource.ProducerType,
            resource.FullName,
            resource.TaxId,
            resource.LegalName,
            resource.Email,
            resource.Phone,
            resource.Country,
            resource.Region,
            resource.City,
            resource.Address,
            resource.Crop,
            resource.CultivatedHectares,
            resource.MonthlyProduction,
            resource.OperationsStartDate,
            resource.Certifications,
            resource.Photo
        );

    public static ProducerResource ToResourceFromEntity(Producer producer) =>
        new(
            producer.Id,
            producer.ProducerType.ToString(),
            producer.FullName,
            producer.TaxId.Value,
            producer.LegalName,
            producer.ContactInfo.Email,
            producer.ContactInfo.Phone,
            producer.Location.Country,
            producer.Location.Region,
            producer.Location.City,
            producer.Location.Address,
            producer.ProductionInfo.Crop,
            producer.ProductionInfo.CultivatedHectares,
            producer.ProductionInfo.MonthlyProduction,
            producer.OperationsStartDate,
            producer.Rating,
            producer.Certifications,
            producer.Photo
        );
}