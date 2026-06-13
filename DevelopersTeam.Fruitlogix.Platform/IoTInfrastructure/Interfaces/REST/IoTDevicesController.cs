using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST.Transform;
using DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Application.CommandServices;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.IoTInfrastructure.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class IoTDevicesController(
    IIoTDeviceQueryService queryService,
    IIoTDeviceCommandService commandService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<IoTDeviceResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDevices()
    {
        var query = new GetAllDevicesQuery();
        var devices = await queryService.Handle(query);
        var resources = devices.Select(IoTDeviceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(IoTDeviceResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDeviceById(int id)
    {
        var query = new GetIoTDeviceByIdQuery(id);
        var device = await queryService.Handle(query);
        if (device is null) return NotFound();
        return Ok(IoTDeviceResourceFromEntityAssembler.ToResourceFromEntity(device));
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(IoTDeviceResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDeviceStatus(int id, [FromBody] UpdateIoTDeviceResource resource)
    {
        try
        {
            var command = UpdateIoTDeviceCommandFromResourceAssembler.ToCommandFromResource(id, resource);
            var device = await commandService.Handle(command);
            if (device is null) return NotFound();
            return Ok(IoTDeviceResourceFromEntityAssembler.ToResourceFromEntity(device));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}