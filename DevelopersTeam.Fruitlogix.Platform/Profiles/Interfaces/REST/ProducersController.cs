using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProducersController(
    IProducerCommandService producerCommandService,
    IProducerQueryService producerQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProducer([FromBody] CreateProducerResource resource)
    {
        try
        {
            var command  = ProducerResourceAssembler.ToCommandFromResource(resource);
            var producer = await producerCommandService.Handle(command);
            var result   = ProducerResourceAssembler.ToResourceFromEntity(producer);
            return CreatedAtAction(nameof(CreateProducer), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
        catch (ArgumentException ex)         { return BadRequest(new { message = ex.Message }); }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducers()
    {
        var query     = new GetAllProducersQuery();
        var producers = await producerQueryService.Handle(query);
        var result    = producers.Select(ProducerResourceAssembler.ToResourceFromEntity);
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProducerById(int id)
    {
        var query    = new GetProducerByIdQuery(id);
        var producer = await producerQueryService.Handle(query);
        if (producer is null) return NotFound(new { message = $"Producer with id {id} not found." });
        return Ok(ProducerResourceAssembler.ToResourceFromEntity(producer));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProducer(int id, [FromBody] UpdateProducerResource resource)
    {
        try
        {
            var command  = ProducerResourceAssembler.ToCommandFromResource(id, resource);
            var producer = await producerCommandService.Handle(command);
            var result   = ProducerResourceAssembler.ToResourceFromEntity(producer);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)      { return NotFound(new { message = ex.Message }); }
        catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
        catch (ArgumentException ex)         { return BadRequest(new { message = ex.Message }); }
    }
}