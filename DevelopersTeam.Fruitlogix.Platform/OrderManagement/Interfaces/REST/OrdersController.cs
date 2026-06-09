using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(
    IOrderCommandService orderCommandService,
    IOrderQueryService orderQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateOrderResource resource)
    {
        var command = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var order = await orderCommandService.Handle(command);
        
        if (order is null) return BadRequest();
        
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return StatusCode(201, orderResource);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
    {
        var orders = await orderQueryService.Handle(new GetAllOrdersQuery());
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}