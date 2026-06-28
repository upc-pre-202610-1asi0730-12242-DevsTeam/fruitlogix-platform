using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class DeliveriesController : ControllerBase
{
    private readonly IDeliveryCommandService _deliveryCommandService;
    private readonly IDeliveryQueryService   _deliveryQueryService;

    public DeliveriesController(
        IDeliveryCommandService deliveryCommandService,
        IDeliveryQueryService deliveryQueryService)
    {
        _deliveryCommandService = deliveryCommandService;
        _deliveryQueryService   = deliveryQueryService;
    }

    /// <summary>Creates a new delivery.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(DeliveryResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDelivery([FromBody] CreateDeliveryResource resource)
    {
        var command  = CreateDeliveryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var delivery = await _deliveryCommandService.Handle(command);
        var result   = DeliveryResourceFromEntityAssembler.ToResourceFromEntity(delivery);
        return CreatedAtAction(nameof(CreateDelivery), new { id = result.Id }, result);
    }

    /// <summary>Returns all deliveries.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DeliveryResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDeliveries()
    {
        var query      = new GetAllDeliveriesQuery();
        var deliveries = await _deliveryQueryService.Handle(query);
        var result     = deliveries.Select(
            DeliveryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(result);
    }

    /// <summary>Starts the dispatch of a delivery.</summary>
    [HttpPost("{id:int}/start-dispatch")]
    [ProducesResponseType(typeof(DeliveryResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> StartDispatch(int id)
    {
        var command  = new StartDispatchCommand(id);
        var delivery = await _deliveryCommandService.Handle(command);
        return Ok(DeliveryResourceFromEntityAssembler.ToResourceFromEntity(delivery));
    }

    /// <summary>Reports a delay for a delivery.</summary>
    [HttpPost("{id:int}/report-delay")]
    [ProducesResponseType(typeof(DeliveryResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ReportDelay(int id, [FromBody] ReportDelayResource resource)
    {
        var command  = new ReportDelayCommand(id, resource.Reason);
        var delivery = await _deliveryCommandService.Handle(command);
        return Ok(DeliveryResourceFromEntityAssembler.ToResourceFromEntity(delivery));
    }
}