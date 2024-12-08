using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Waste_Management_and_Recycling_System.Middlewares
{
    public class AuthorizationMiddleWare
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<AuthorizationMiddleWare> _logger;
        public AuthorizationMiddleWare(RequestDelegate requestDelegate, ILogger<AuthorizationMiddleWare> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Login required.");
                return;
            }
            var expirationClaim = context.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (expirationClaim != null && DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim)).UtcDateTime)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Token has expired.");
                return;
            }
            _logger.LogInformation($"User {context.User.Identity.Name} accessed {context.Request.Path}");
            await _requestDelegate(context);


        }
    }
}
