using Mariner.Application.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Mariner.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITenantService tenantService)
        {
            string tenantIdentifier = context.User?.FindFirst("TenantId")?.Value;

            if (!string.IsNullOrEmpty(tenantIdentifier))
            {
                var connectionString = tenantService.GetConnectionString(tenantIdentifier);

                if (!string.IsNullOrEmpty(connectionString))
                {
                    context.Items["TenantConnection"] = connectionString;
                }
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TenantMiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantMiddleware>();
        }
    }
}
