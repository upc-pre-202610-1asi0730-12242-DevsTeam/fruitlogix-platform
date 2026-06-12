using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InvoicesController(
    IInvoiceCommandService invoiceCommandService,
    IInvoiceQueryService invoiceQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(InvoiceResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceResource resource)
    {
        var command = CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var invoice = await invoiceCommandService.Handle(command);
        if (invoice is null) return BadRequest();
        var invoiceResource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return StatusCode(201, invoiceResource);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InvoiceResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInvoices()
    {
        var query = new GetAllInvoicesQuery();
        var invoices = await invoiceQueryService.Handle(query);
        var resources = invoices.Select(InvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InvoiceResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var query = new GetInvoiceByIdQuery(id);
        var invoice = await invoiceQueryService.Handle(query);
        if (invoice is null) return NotFound();
        return Ok(InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice));
    }
}