using System.Net;
using System.Text.Json;

namespace CodeChallengeBF.Infra.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware( RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger )
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke( HttpContext context )
        {
            try
            {
                await _next( context );
            }
            catch (Exception exception)
            {
                // Log the error
                _logger.LogError( string.Format( "error during executing '{0} {1}'", context.Request.Method, context.Request.Path.Value ), exception );
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync( JsonSerializer.Serialize( new
                {
                    errorMessage = exception.Message,
                    errorType = exception.GetType().Name
                } ) );
            }
        }
    }
}
