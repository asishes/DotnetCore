using Mariner.Application.Dto;
using Mariner.Application.Repository.Interface;
using Mariner.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Mariner.Persistence.Repository.Implementation
{
    public class TenantService : ITenantService
    {
        private readonly MarinerContext _context;

        public TenantService(MarinerContext context) 
        {
            _context = context;
        }
        public Task AddTenantAsync(string tenantName)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString(string tenantId)
        {
            var tenant = _context.TenantSet.FirstOrDefault(t => t.TenantId.ToString() == tenantId);
            return tenant?.ConnectionString;
        }

        public Task<TenantDto> GetTenantByNameAsync(string tenantName)
        {
            throw new NotImplementedException();
        }
    }
}
