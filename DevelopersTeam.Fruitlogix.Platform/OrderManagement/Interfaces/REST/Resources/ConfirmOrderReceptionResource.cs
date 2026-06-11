namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

public record ConfirmOrderReceptionResource(
    int Rating,
    string Comment,
    bool HasIncidence
);