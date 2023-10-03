namespace TestingApplication.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName,
                out var extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key missing.");
                return;
            }
            string? apiKey = _configuration.GetValue<string>(AuthConstants.ApiSectionName);
            if (!apiKey.Equals(extractedKey)) 
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
            }
            await _next(context);
        }
    }
}
