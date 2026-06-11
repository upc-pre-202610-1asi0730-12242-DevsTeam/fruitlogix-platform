using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class IncidentsController(
    IIncidentCommandService commandService,
    IIncidentQueryService queryService        // ← nuevo
) : ControllerBase
{
    // GET api/v1/incidents
    [HttpGet]
    public async Task<IActionResult> GetAllIncidents()
    {
        var query     = new GetAllIncidentsQuery();
        var incidents = await queryService.Handle(query);
        var result    = incidents.Select(IncidentResourceAssembler.ToResourceFromEntity);
        return Ok(result);
    }

    // POST api/v1/incidents
    [HttpPost]
    public async Task<IActionResult> CreateIncident([FromBody] CreateIncidentResource resource)
    {
        var command  = IncidentResourceAssembler.ToCommandFromResource(resource);
        var incident = await commandService.Handle(command);
        var result   = IncidentResourceAssembler.ToResourceFromEntity(incident);
        return CreatedAtAction(nameof(CreateIncident), new { id = result.Id }, result);
    }
}