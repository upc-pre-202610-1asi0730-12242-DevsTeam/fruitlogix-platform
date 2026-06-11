using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;

public static class ConfirmOrderReceptionCommandFromResourceAssembler
{
    public static ConfirmOrderReceptionCommand ToCommandFromResource(
        int orderId, ConfirmOrderReceptionResource resource)
    {
        return new ConfirmOrderReceptionCommand(
            orderId, 
            resource.Rating, 
            resource.Comment, 
            resource.HasIncidence
        );
    }
}