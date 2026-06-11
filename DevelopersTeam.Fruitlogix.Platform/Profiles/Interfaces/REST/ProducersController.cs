// Ruta: Profiles/Interfaces/REST/ProducersController.cs
using DevelopersTeam.Fruitlogix.Platform.Profiles.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProducersController(IProducerCommandService producerCommandService) : ControllerBase
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
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}