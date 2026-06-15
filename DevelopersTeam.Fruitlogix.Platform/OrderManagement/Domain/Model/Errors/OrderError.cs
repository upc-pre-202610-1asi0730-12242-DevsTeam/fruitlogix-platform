namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Errors;

public enum OrderError
{
    OrderNotFound,
    InvalidStatusTransition,
    CannotEditNonPendingOrder,
    ProducerAlreadyAssigned,
    OrderAlreadyCancelled,
    OrderAlreadyDelivered
}