using Mariner.Domain.Common;

namespace Mariner.Domain.Entities
{
    public class TestTakers : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormNumber { get; set; }
        public string BannerID { get; set; }
    }
}
