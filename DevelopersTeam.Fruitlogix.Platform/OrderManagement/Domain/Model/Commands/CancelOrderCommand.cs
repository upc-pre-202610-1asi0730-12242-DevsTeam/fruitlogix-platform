namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record CancelOrderCommand(
    int OrderId,
    string Reason
);