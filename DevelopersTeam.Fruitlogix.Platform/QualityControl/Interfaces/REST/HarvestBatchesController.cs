using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class HarvestBatchesController(IHarvestBatchCommandService commandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateHarvestBatch([FromBody] CreateHarvestBatchResource resource)
    {
        var command = HarvestBatchResourceAssembler.ToCommandFromResource(resource);
        var batch   = await commandService.Handle(command);
        var result  = HarvestBatchResourceAssembler.ToResourceFromEntity(batch);
        return CreatedAtAction(nameof(CreateHarvestBatch), new { id = result.Id }, result);
    }
}