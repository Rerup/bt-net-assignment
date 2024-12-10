using System.Diagnostics;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Stopwatch watch = new Stopwatch();

        watch.Start();

        context.Response.OnStarting(() =>
        {
            watch.Stop();

            context.Response.Headers.Append("x-time", watch.ElapsedMilliseconds.ToString());

            return Task.CompletedTask;
        });

        await _next(context);
    }
}
