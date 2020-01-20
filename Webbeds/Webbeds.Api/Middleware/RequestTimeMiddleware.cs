using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Webbeds.Api.Middleware
{
    public class RequestTimeMiddleware : BaseMiddleware
    {
        public RequestTimeMiddleware(RequestDelegate next) : base(next)
        {}

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await this.next.Invoke(context);

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
