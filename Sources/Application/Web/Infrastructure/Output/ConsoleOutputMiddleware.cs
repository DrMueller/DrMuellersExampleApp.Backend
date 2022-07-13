namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Output
{
    public class ConsoleOutputMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine(context.Request.Path);

            await next(context);
        }
    }
}
