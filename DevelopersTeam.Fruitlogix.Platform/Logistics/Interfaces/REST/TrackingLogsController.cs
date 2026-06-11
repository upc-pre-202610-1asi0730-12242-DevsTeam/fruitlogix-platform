using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/tracking-logs")]
[Produces(MediaTypeNames.Application.Json)]
public class TrackingLogsController : ControllerBase
{
    private readonly ITrackingLogCommandService _trackingLogCommandService;
    private readonly ITrackingLogQueryService   _trackingLogQueryService;

    public TrackingLogsController(
        ITrackingLogCommandService trackingLogCommandService,
        ITrackingLogQueryService   trackingLogQueryService)
    {
        _trackingLogCommandService = trackingLogCommandService;
        _trackingLogQueryService   = trackingLogQueryService;
    }

    /// <summary>Receives a telemetry reading from an IoT device.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(TrackingLogResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTrackingLog([FromBody] CreateTrackingLogResource resource)
    {
        var command = CreateTrackingLogCommandFromResourceAssembler.ToCommandFromResource(resource);
        var log     = await _trackingLogCommandService.Handle(command);
        var result  = TrackingLogResourceFromEntityAssembler.ToResourceFromEntity(log);
        return CreatedAtAction(nameof(CreateTrackingLog), new { id = result.Id }, result);
    }

    /// <summary>Returns all tracking logs for a specific delivery.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TrackingLogResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTrackingLogsByDeliveryId([FromQuery] int deliveryId)
    {
        var query  = new GetTrackingLogsByDeliveryIdQuery(deliveryId);
        var logs   = await _trackingLogQueryService.Handle(query);
        var result = logs.Select(TrackingLogResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(result);
    }
}