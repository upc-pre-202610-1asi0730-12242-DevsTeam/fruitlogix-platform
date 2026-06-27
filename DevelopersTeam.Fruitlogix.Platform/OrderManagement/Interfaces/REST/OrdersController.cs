using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await orderQueryService.Handle(new GetOrderByIdQuery(id));
        if (order is null) return NotFound();
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(order));
    }

    [HttpGet("client/{clientId:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetByClientId(int clientId)
    {
        var orders = await orderQueryService.Handle(new GetOrdersByClientIdQuery(clientId));
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderResource resource)
    {
        var command = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var order = await orderCommandService.Handle(command);
        if (order is null) return NotFound();
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(order));
    }

    [HttpPatch("{id:int}/assign-producer")]
    public async Task<IActionResult> AssignProducer(int id, [FromBody] AssignProducerResource resource)
    {
        if (resource?.ProducerId == null)
            return BadRequest(new { message = "ProducerId is required." });
    
        var command = AssignProducerCommandFromResourceAssembler
            .ToCommandFromResource(id, resource);
        var order = await orderCommandService.Handle(command);
        if (order is null) return NotFound();
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(order));
    }

    [HttpPatch("{id:int}/cancel")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Cancel(int id, [FromBody] CancelOrderResource resource)
    {
        var command = new Domain.Model.Commands.CancelOrderCommand(id, resource.Reason);
        var order = await orderCommandService.Handle(command);
        if (order is null) return NotFound();
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(order));
    }
    
    [HttpPost("{orderId:int}/reception")]
    public async Task<IActionResult> ConfirmOrderReception(
        int orderId, [FromBody] ConfirmOrderReceptionResource resource)
    {
        // Usamos el nuevo Assembler que acabas de crear
        var command = ConfirmOrderReceptionCommandFromResourceAssembler.ToCommandFromResource(orderId, resource);
    
        var order = await orderCommandService.Handle(command);

        if (order is null)
            return NotFound($"Order with id {orderId} not found.");

        // Aquí sí usamos el Assembler viejo porque vamos de Entity a Resource para mostrar el resultado
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(order));
    }
    
    [HttpGet("producer/{producerId:int}")]
    public async Task<IActionResult> GetByProducerId(int producerId)
    {
        var orders = await orderQueryService.Handle(
            new GetOrdersByProducerIdQuery(producerId));
        var resources = orders.Select(
            OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    /// <summary>
    ///     Deletes an order permanently.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to delete.</param>
    /// <returns>204 No Content on success.</returns>
    [HttpDelete("{orderId:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        try
        {
            var command = new DeleteOrderCommand(orderId);
            await orderCommandService.Handle(command);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}