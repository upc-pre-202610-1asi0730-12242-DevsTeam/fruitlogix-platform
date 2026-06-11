// Ruta: QualityControl/Interfaces/REST/QualityInspectionsController.cs
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.QualityControl.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class QualityInspectionsController(
    IQualityInspectionCommandService commandService
) : ControllerBase
{
    // POST api/v1/quality-inspections
    [HttpPost]
    public async Task<IActionResult> CreateQualityInspection(
        [FromBody] CreateQualityInspectionResource resource)
    {
        var command    = QualityInspectionResourceAssembler.ToCommandFromResource(resource);
        var inspection = await commandService.Handle(command);
        var result     = QualityInspectionResourceAssembler.ToResourceFromEntity(inspection);

        return CreatedAtAction(nameof(CreateQualityInspection),
            new { id = result.Id }, result);
    }
}