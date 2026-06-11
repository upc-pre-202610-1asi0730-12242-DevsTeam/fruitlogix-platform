using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class QualityInspectionsController(
    IQualityInspectionCommandService commandService,
    IQualityInspectionQueryService   queryService
) : ControllerBase
{
    // GET api/v1/quality-inspections/batch/{batchId}
    [HttpGet("batch/{batchId:int}")]
    public async Task<IActionResult> GetByBatchId(int batchId)
    {
        var query      = new GetQualityInspectionByBatchIdQuery(batchId);
        var inspection = await queryService.Handle(query);

        if (inspection is null)
            return NotFound($"No quality inspection found for batch {batchId}.");

        return Ok(QualityInspectionResourceAssembler.ToResourceFromEntity(inspection));
    }

    // POST api/v1/quality-inspections
    [HttpPost]
    public async Task<IActionResult> CreateQualityInspection(
        [FromBody] CreateQualityInspectionResource resource)
    {
        var command    = QualityInspectionResourceAssembler.ToCommandFromResource(resource);
        var inspection = await commandService.Handle(command);
        var result     = QualityInspectionResourceAssembler.ToResourceFromEntity(inspection);

        return CreatedAtAction(nameof(GetByBatchId),
            new { batchId = result.BatchId }, result);
    }
}