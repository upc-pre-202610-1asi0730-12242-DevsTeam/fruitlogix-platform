using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.PaymentManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/payment-transactions")]
public class PaymentTransactionsController(
    IPaymentTransactionCommandService paymentTransactionCommandService,
    IPaymentTransactionQueryService paymentTransactionQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(PaymentTransactionResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePaymentTransaction(
        [FromBody] CreatePaymentTransactionResource resource)
    {
        var command = CreatePaymentTransactionCommandFromResourceAssembler
            .ToCommandFromResource(resource);
        var transaction = await paymentTransactionCommandService.Handle(command);
        if (transaction is null) return NotFound();
        var transactionResource =
            PaymentTransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return StatusCode(201, transactionResource);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PaymentTransactionResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPaymentTransactions()
    {
        var query = new GetAllPaymentTransactionsQuery();
        var transactions = await paymentTransactionQueryService.Handle(query);
        var resources = transactions
            .Select(PaymentTransactionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}