using Mariner.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Mariner.Persistence.Context
{
    public class MarinerContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MarinerContext(DbContextOptions<MarinerContext> options, 
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (_httpContextAccessor.HttpContext.Items["TenantConnection"] is string connectionString)
        //    {
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
        public DbSet<TestTakers> TestTakers { get; set; }
        public DbSet<Tenant> TenantSet { get; set; }
    }
}
