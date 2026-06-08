using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(IOrderCommandService orderCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderResource resource)
    {
        var command = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var order = await orderCommandService.Handle(command);
        
        if (order is null) return BadRequest();
        
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        
        // Usamos StatusCode 201 porque el endpoint GetById pertenece a otra rama
        return StatusCode(201, orderResource);
    }
}