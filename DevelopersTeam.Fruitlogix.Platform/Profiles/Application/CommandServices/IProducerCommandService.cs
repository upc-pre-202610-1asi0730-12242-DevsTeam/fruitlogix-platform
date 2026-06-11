using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Commands;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Application.CommandServices;

public interface IProducerCommandService
{
    Task<Producer> Handle(CreateProducerCommand command);
    
    Task<Producer> Handle(UpdateProducerCommand command);

}