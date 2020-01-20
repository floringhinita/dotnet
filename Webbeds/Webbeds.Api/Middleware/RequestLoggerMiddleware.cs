namespace Webbeds.Api.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class RequestLoggerMiddleware : BaseMiddleware
    {
        private readonly ILogger logger;

        public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) : base(next)
        { 
            this.logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            this.logger.LogInformation("Handling request: " + context.Request.Path);
            await this.next.Invoke(context);
            this.logger.LogInformation("Finished handling request.");
        } 
    }
}
