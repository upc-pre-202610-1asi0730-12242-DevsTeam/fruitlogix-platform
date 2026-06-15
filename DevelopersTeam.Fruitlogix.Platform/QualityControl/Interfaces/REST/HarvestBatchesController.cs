using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class HarvestBatchesController(
    IHarvestBatchCommandService commandService,
    IHarvestBatchQueryService queryService
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllHarvestBatches()
    {
        var query   = new GetAllHarvestBatchesQuery();
        var batches = await queryService.Handle(query);
        var result  = batches.Select(HarvestBatchResourceAssembler.ToResourceFromEntity);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHarvestBatch([FromBody] CreateHarvestBatchResource resource)
    {
        var command = HarvestBatchResourceAssembler.ToCommandFromResource(resource);
        var batch   = await commandService.Handle(command);
        var result  = HarvestBatchResourceAssembler.ToResourceFromEntity(batch);
        return CreatedAtAction(nameof(CreateHarvestBatch), new { id = result.Id }, result);
    }
    
    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateHarvestBatchStatus(
        int id, [FromBody] UpdateHarvestBatchStatusResource resource)
    {
        try
        {
            var command = HarvestBatchResourceAssembler.ToCommandFromResource(id, resource);
            var batch   = await commandService.Handle(command);

            if (batch is null)
                return NotFound($"HarvestBatch with id {id} not found.");

            return Ok(HarvestBatchResourceAssembler.ToResourceFromEntity(batch));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}