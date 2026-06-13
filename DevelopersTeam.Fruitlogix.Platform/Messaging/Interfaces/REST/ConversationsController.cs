using System.Net.Mime;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Application.CommandServices;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Resources;
using DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Messaging.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ConversationsController(IConversationCommandService conversationCommandService)
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
}