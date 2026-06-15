namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record AssignProducerCommand(
    int OrderId,
    int ProducerId
);