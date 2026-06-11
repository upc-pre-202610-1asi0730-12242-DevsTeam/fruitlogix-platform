using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Repositories;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Application.Internal.CommandServices;

public class ProducerCommandService(
    IProducerRepository producerRepository,
    IUnitOfWork unitOfWork) : IProducerCommandService
{
    public async Task<Producer> Handle(CreateProducerCommand command)
    {
        if (await producerRepository.ExistsByTaxIdAsync(command.TaxId))
            throw new InvalidOperationException($"A producer with TaxId '{command.TaxId}' already exists.");

        var producer = new Producer(command);
        await producerRepository.AddAsync(producer);
        await unitOfWork.CompleteAsync();
        return producer;
    }
    
    public async Task<Producer> Handle(UpdateProducerCommand command)
    {
        var producer = await producerRepository.FindByIdAsync(command.Id)
                       ?? throw new KeyNotFoundException($"Producer with id {command.Id} not found.");

        // Validar TaxId duplicado solo si está cambiando
        if (producer.TaxId.Value != command.TaxId)
        {
            var existing = await producerRepository.FindByTaxIdAsync(command.TaxId);
            if (existing is not null)
                throw new InvalidOperationException($"TaxId '{command.TaxId}' is already in use.");
        }

        producer.Update(command);
        producerRepository.Update(producer);
        await unitOfWork.CompleteAsync();
        return producer;
    }
}