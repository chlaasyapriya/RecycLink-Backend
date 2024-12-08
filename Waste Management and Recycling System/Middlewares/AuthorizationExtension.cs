namespace Waste_Management_and_Recycling_System.Middlewares
{
    public static class AuthorizationExtension
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthorizationMiddleWare>();
        }
    }
}
