using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
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

    public DeliveriesController(IDeliveryCommandService deliveryCommandService)
    {
        _deliveryCommandService = deliveryCommandService;
    }

    /// <summary>Creates a new delivery.</summary>
    /// <param name="resource">Delivery creation payload.</param>
    /// <returns>The created delivery.</returns>
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
}