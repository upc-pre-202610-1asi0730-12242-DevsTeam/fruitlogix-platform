using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AlertRulesController(IAlertRuleCommandService commandService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(AlertRuleResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAlertRule([FromBody] CreateAlertRuleResource resource)
    {
        try
        {
            var command = CreateAlertRuleCommandFromResourceAssembler.ToCommandFromResource(resource);
            var rule = await commandService.Handle(command);
            return StatusCode(201, AlertRuleResourceFromEntityAssembler.ToResourceFromEntity(rule));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}