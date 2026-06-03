using Microsoft.AspNetCore.Mvc;

namespace DevelopersTeam.Fruitlogix.Platform.Shared.Interfaces.Rest.ProblemDetails;

/// <summary>
///     Factory for creating standardized ProblemDetails HTTP responses.
/// </summary>
public static class FruitlogixProblemDetailsFactory
{
    public static IActionResult CreateBadRequest(ControllerBase controller, string detail) =>
        controller.BadRequest(new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = 400,
            Title = "Bad Request",
            Detail = detail,
            Instance = controller.HttpContext.Request.Path
        });

    public static IActionResult CreateNotFound(ControllerBase controller, string detail) =>
        controller.NotFound(new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = 404,
            Title = "Not Found",
            Detail = detail,
            Instance = controller.HttpContext.Request.Path
        });

    public static IActionResult CreateConflict(ControllerBase controller, string detail) =>
        controller.Conflict(new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = 409,
            Title = "Conflict",
            Detail = detail,
            Instance = controller.HttpContext.Request.Path
        });
}