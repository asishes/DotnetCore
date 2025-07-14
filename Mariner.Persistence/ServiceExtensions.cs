using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mariner.Application.Repository;
using Mariner.Application.Repository.TestTakersRepository;
using Mariner.Persistence.Context;
using Mariner.Persistence.Repository;
using Mariner.Persistence.Repository.TestTakersRepository;
using Mariner.Application.Repository.Interface;
using Mariner.Persistence.Repository.Implementation;
using Microsoft.AspNetCore.Http;

namespace Mariner.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            var connection = configuration.GetConnectionString("MarinerContext");
            services.AddDbContext<MarinerContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<MarinerContext>((serviceProvider, options) =>
            // {
            //     var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //     string connectionString = httpContextAccessor.HttpContext?.Items["TenantConnection"]?.ToString();

            //     if (!string.IsNullOrEmpty(connectionString))
            //     {
            //         options.UseSqlServer(connectionString);
            //     }
            // });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITestTakerRepository, TestTakerRepository>();
            services.AddScoped<ITenantService, TenantService>();
            
        }
    }
}
