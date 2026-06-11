using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InvoicesController(IInvoiceCommandService invoiceCommandService) : ControllerBase
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
}