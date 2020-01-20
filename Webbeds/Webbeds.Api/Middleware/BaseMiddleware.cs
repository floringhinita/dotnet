namespace Webbeds.Api.Middleware
{
    using Microsoft.AspNetCore.Http;
     
    public class BaseMiddleware
    {
        protected readonly RequestDelegate next;

        public BaseMiddleware(RequestDelegate next)
        {
            this.next = next;
        } 
    }
}
