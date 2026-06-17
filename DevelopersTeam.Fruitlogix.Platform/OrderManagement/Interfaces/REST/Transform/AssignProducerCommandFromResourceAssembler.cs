using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class AssignProducerCommandFromResourceAssembler
{
    public static AssignProducerCommand ToCommandFromResource(int orderId, AssignProducerResource resource) =>
        new(orderId, resource.ProducerId!.Value);
}