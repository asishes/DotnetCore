
using Mariner.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mariner.Domain.Entities
{
    [Table("Tenants")]
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string ConnectionString { get; set; }
    }
}
