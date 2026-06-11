namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

public record ConfirmOrderReceptionCommand(
    int OrderId,
    int Rating,
    string Comment,
    bool HasIncidence
);