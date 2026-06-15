using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ConversationsController(IConversationCommandService conversationCommandService, IMessageCommandService messageCommandService, IMessageQueryService messageQueryService, IConversationQueryService   conversationQueryService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ConversationResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConversation([FromBody] CreateConversationResource resource)
    {
        try
        {
            var command = ConversationResourceAssembler.ToCommandFromResource(resource);
            var conversation = await conversationCommandService.Handle(command);
            var result = ConversationResourceAssembler.ToResourceFromEntity(conversation);
            
            return StatusCode(201, result); 
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("{conversationId:int}/messages")]
    [ProducesResponseType(typeof(MessageResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendMessage(
        int conversationId, [FromBody] SendMessageResource resource)
    {
        try
        {
            var command = MessageResourceAssembler.ToCommandFromResource(conversationId, resource);
            var message = await messageCommandService.Handle(command);
            var result  = MessageResourceAssembler.ToResourceFromEntity(message);
            return StatusCode(201, result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{conversationId:int}/messages")]
    [ProducesResponseType(typeof(IEnumerable<MessageResource>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Agregamos estas dos líneas
    public async Task<IActionResult> GetMessages(int conversationId)
    {
        try
        {
            var query    = new GetMessagesByConversationIdQuery(conversationId);
            var messages = await messageQueryService.Handle(query);
            var result   = messages.Select(MessageResourceAssembler.ToResourceFromEntity);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ConversationResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetConversations([FromQuery] int? userId)
    {
        IEnumerable<Conversation> conversations;

        if (userId.HasValue)
        {
            var query = new GetConversationsByUserIdQuery(userId.Value);
            conversations = await conversationQueryService.Handle(query);
        }
        else
        {
            var query = new GetAllConversationsQuery();
            conversations = await conversationQueryService.Handle(query);
        }

        var result = conversations.Select(ConversationResourceAssembler.ToResourceFromEntity);
        return Ok(result);
    }
}