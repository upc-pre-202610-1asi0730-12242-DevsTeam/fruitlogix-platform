using DevelopersTeam.Fruitlogix.Platform.Iam.Application.Internal.OutboundServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Application.QueryServices;
using DevelopersTeam.Fruitlogix.Platform.Iam.Domain.Model.Queries;
using DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Pipeline.Middleware.Attributes;

namespace DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Pipeline.Middleware.Components;

/**
 * RequestAuthorizationMiddleware is a custom middleware.
 * This middleware is used to authorize requests.
 * It validates a token is included in the request header and that the token is valid.
 * If the token is valid then it sets the user in HttpContext.Items["User"].
 */
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /**
     * InvokeAsync is called by the ASP.NET Core runtime.
     * It is used to authorize requests.
     * It validates a token is included in the request header and that the token is valid.
     * If the token is valid then it sets the user in HttpContext.Items["User"].
     */
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        var cancellationToken = context.RequestAborted;

        var endpoint = context.GetEndpoint();

        // Si no hay endpoint resuelto (ruta no mapeada a ningún controlador:
        // "/", favicon, assets de Swagger, etc.), simplemente deja pasar.
        if (endpoint is null)
        {
            await next(context);
            return;
        }

        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
        var allowAnonymous = endpoint.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));

        if (allowAnonymous)
        {
            await next(context);
            return;
        }

        // get token from request header
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null) throw new Exception("Null or invalid token");

        var userId = await tokenService.ValidateToken(token);
        if (userId == null) throw new Exception("Invalid token");

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery, cancellationToken);
        context.Items["User"] = user;

        await next(context);
    }
}