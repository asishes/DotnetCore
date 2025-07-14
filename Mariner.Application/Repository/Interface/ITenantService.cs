using Mariner.Application.Dto;

namespace Mariner.Application.Repository.Interface
{
    public interface ITenantService
    {
        Task<TenantDto> GetTenantByNameAsync(string tenantName);
        string GetConnectionString(string tenantId);
        Task AddTenantAsync(string tenantName);
    }
}
